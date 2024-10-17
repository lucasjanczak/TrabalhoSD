using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Services;

public class AddressService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    // Get All Addresses
    public async Task<IEnumerable<Address>> GetAllAsync()
    {
        return await _context.Addresses.ToListAsync();
    }

    // Get Address by Id
    public async Task<Address?> GetByIdAsync(int id)
    {
        return await _context.Addresses.FindAsync(id);
    }

    // Create Address
    public async Task<Address> CreateAsync(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return address;
    }

    // Update Address
    public async Task<Address?> UpdateAsync(int id, Address address)
    {
        if (id != address.Id)
        {
            return null; // Id mismatch
        }

        _context.Entry(address).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return address;
    }

    // Delete Address
    public async Task<bool> DeleteAsync(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return false; // Address not found
        }

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
        return true; // Successfully deleted
    }
}
