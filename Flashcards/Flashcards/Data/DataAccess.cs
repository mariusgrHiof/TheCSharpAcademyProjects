using Flashcards.Models;
using Microsoft.EntityFrameworkCore;

namespace Flashcards.Data;
public class DataAccess
{
    private readonly FlashcardsDbContext _context;

    public DataAccess(FlashcardsDbContext context)
    {
        _context = context;
    }

    public async Task<List<Stack>> GetAllStacksAsync()
    {
        try
        {
            return await _context.Stacks.ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }


    }
    public async Task<List<Stack>> GetAllStacksWithFlashcardsAsync()
    {
        return await _context.Stacks
            .Include(s => s.Flashcards)
            .ToListAsync();
    }

    public async Task<Stack> GetStackByIdAsync(int id)
    {
        var stack = await _context.Stacks.FirstOrDefaultAsync(s => s.Id == id);
        if (stack == null)
        {
            return null;
        }

        return stack;
    }
    public async Task<Stack> GetStackWithFlashcardsByIdAsync(int id)
    {
        var stack = await _context.Stacks
            .Include(s => s.Flashcards)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (stack == null)
        {
            return null;
        }

        return stack;
    }

    public async Task<Stack> UpdateStackByIdAsync(int id, Stack Updatestack)
    {
        if (Updatestack == null) return null;
        if (Updatestack.Id != id) return null;

        var stack = await _context.Stacks.FirstOrDefaultAsync(stack => stack.Id == id);

        if (stack == null)
        {
            return null;
        }

        stack.Id = Updatestack.Id;
        stack.Name = Updatestack.Name;

        _context.Stacks.Update(stack);

        try
        {
            await _context.SaveChangesAsync();

            return stack;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fail to update record. Details: ", ex.Message);

        }
        return stack;
    }

    public async Task<Stack> DeleteStackByIdAsync(int id)
    {
        var stack = await _context.Stacks.FirstOrDefaultAsync(s => s.Id == id);
        if (stack == null) return null;

        _context.Stacks.Remove(stack);
        try
        {
            await _context.SaveChangesAsync();
            return stack;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fail to delete record. Details: {ex.Message}");
            return null;
        }
    }

    public async Task<Stack> AddStackAsync(Stack stack)
    {
        if (stack == null) return null;

        _context.Stacks.Add(stack);

        try
        {
            await _context.SaveChangesAsync();

            return stack;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fail to add record.Details: {ex.Message}");
            return null;
        }
    }

    public async Task<Flashcard> AddFlashcardAsync(int stackId, Flashcard flashcard)
    {
        if (flashcard == null) return null;
        var stack = await _context.Stacks
            .Include(s => s.Flashcards)
            .FirstOrDefaultAsync(s => s.Id == stackId);

        if (stack == null) return null;

        stack.Flashcards.Add(flashcard);

        try
        {
            await _context.SaveChangesAsync();
            return flashcard;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fail to add record.Details: {ex.Message}");
            return null;
        }
    }

    public async Task<Flashcard> UpdateFlashcardAsync(int stackId, Flashcard updateFlashcard)
    {
        Flashcard flashcard = null;

        if (updateFlashcard == null) return null;
        var stack = await _context.Stacks
            .Include(s => s.Flashcards)
            .FirstOrDefaultAsync(s => s.Id == stackId);

        if (stack != null)
        {
            flashcard = stack.Flashcards.FirstOrDefault(fc => fc.Id == updateFlashcard.Id);
            if (flashcard == null) return null;

            flashcard.Question = updateFlashcard.Question;
            flashcard.Answer = updateFlashcard.Answer;

            var index = stack.Flashcards.IndexOf(flashcard);

            if (index != -1)
            {
                stack.Flashcards[index] = flashcard;
            }
            else
            {
                Console.WriteLine("Phone number not found.");
            }
        }

        _context.Stacks.Update(stack);

        try
        {
            await _context.SaveChangesAsync();
            return flashcard;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fail to add record.Details: {ex.Message}");
            return null;
        }
    }

    public async Task<Flashcard> DeleteFlashcardAsync(int stackId, int flashcardId)
    {

        var stack = await _context.Stacks
            .Include(s => s.Flashcards)
            .FirstOrDefaultAsync(s => s.Id == stackId);

        if (stack == null) return null;

        var flashcard = stack.Flashcards.FirstOrDefault(f => f.Id == flashcardId);
        if (flashcard == null) return null;

        stack.Flashcards.Remove(flashcard);

        try
        {
            await _context.SaveChangesAsync();
            return flashcard;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fail to delete record.Details: {ex.Message}");
            return null;
        }
    }

    public void EnsureDbExists()
    {
        // Check if the database exists
        if (!_context.Database.CanConnect())
        {
            Console.WriteLine("Database does not exist. Creating...");

            // Create the database
            _context.Database.EnsureCreated();

            Console.WriteLine("Database created successfully.");
        }
        else
        {
            return;
        }
    }

}

