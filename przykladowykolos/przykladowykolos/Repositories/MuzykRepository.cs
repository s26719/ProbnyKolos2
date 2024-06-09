using System.Globalization;
using Microsoft.EntityFrameworkCore;
using przykladowykolos.Context;
using przykladowykolos.DTO_s;
using przykladowykolos.Exception;
using przykladowykolos.Models;

namespace przykladowykolos.Repositories;

public class MuzykRepository : IMuzykRepository
{
    private readonly MyDbContext _mydbContext;

    public MuzykRepository(MyDbContext mydbContext)
    {
        _mydbContext = mydbContext;
    }

    public async Task<MuzykOutDto> GetMuzykDetailsAsync(int id)
    {
        
        var muzyk = await _mydbContext.Muzyks
            .Where(m => m.IdMuzyk == id)
            .Select(m => new MuzykOutDto
            {
                IdMuzyk = m.IdMuzyk,
                Imie = m.Imie,
                Nazwisko = m.Nazwisko,
                Pseudonim = m.Pseudonim,
                UtworOutDtos = m.WykonawcaUtworu.Select(wu => new UtworOutDto
                {
                    IdUtwor = wu.IdUtworNavigation.IdUtwor,
                    NazwaUtworu = wu.IdUtworNavigation.NazwaUtworu,
                    CzasTrwania = wu.IdUtworNavigation.CzasTrwania
                }).ToList()
            }).FirstOrDefaultAsync();
        if (muzyk == null)
        {
            throw new NotFoundException("muzyk o podanym id nie istnieje");
        }
        return muzyk;
    }

    public async Task AddNewMuzykAsync(MuzykInDto muzykInDto)
    {
        await using var transaction = await _mydbContext.Database.BeginTransactionAsync();

        try
        {
            // Create and save the new Muzyk entity
            var muzyk = new Muzyk
            {
                Imie = muzykInDto.imie,
                Nazwisko = muzykInDto.Nazwisko,
                Pseudonim = muzykInDto.Pseudonim
            };
            await _mydbContext.AddAsync(muzyk);
            await _mydbContext.SaveChangesAsync();

            // Check if IdAlbum is provided and valid
            var album = await _mydbContext.Albums.FindAsync(muzykInDto.Utwor.IdAlbum);
            if (album == null)
            {
                throw new BadRequestException("Invalid Album ID provided.");
            }

            // Create and save the new Utwor entity
            var utwor = new Utwor
            {
                NazwaUtworu = muzykInDto.Utwor.NazwaUtworu,
                CzasTrwania = muzykInDto.Utwor.CzasTrwania,
                IdAlbum = muzykInDto.Utwor.IdAlbum // Ensure the Album ID is included
            };
            await _mydbContext.AddAsync(utwor);
            await _mydbContext.SaveChangesAsync();

            // Create and save the new WykonawcaUtworu entity
            var wykonawcaUtworu = new WykonawcaUtworu
            {
                IdMuzyk = muzyk.IdMuzyk,
                IdUtwor = utwor.IdUtwor
            };
            await _mydbContext.AddAsync(wykonawcaUtworu);
            await _mydbContext.SaveChangesAsync();

            // Commit the transaction
            await transaction.CommitAsync();
        }
        catch (NotFoundException e)
        {
            await transaction.RollbackAsync();
            throw new NotFoundException("Failed to add the new musician and related entities.");
        }
        catch (BadRequestException e)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(e.Message);
        }
    }

}