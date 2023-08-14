﻿using Flashcards.MartinL_no.Models;

namespace Flashcards.MartinL_no.Controllers;

internal class StackManagerController
{
    private readonly IFlashcardStackRepository _stackRepo;

    public StackManagerController(IFlashcardStackRepository stackRepo)
    {
        _stackRepo = stackRepo;
    }

    public List<FlashcardStackDTO> GetStacks()
    {
        return _stackRepo.GetStacks()
            .Select(s => StackToDTO(s))
            .ToList();
    }

    public List<string> GetStackNames()
    {
        var stacks = _stackRepo.GetStacks();
        return stacks.Select(s => s.Name).ToList();
    }

    public FlashcardStackDTO GetStackByName(string name)
    {
        var stack = _stackRepo.GetStackByName(name);
        return StackToDTO(stack);
    }

    public bool CreateStack(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            var stack = new FlashcardStack() { Name = name };
            return _stackRepo.InsertStack(stack);
        }

        return false;
    }

    public bool CreateFlashcard(string front, string back, int stackId)
    {
        if (!string.IsNullOrWhiteSpace(front) && !string.IsNullOrWhiteSpace(back))
        {
            var flashcard = new Flashcard() { Front = front, Back = back, StackId = stackId };

            return _stackRepo.InsertFlashcard(flashcard);
        }

        return false;
    }

    public bool UpdateFlashcard(int id, string front, string back, int stackId)
    {
        if (id > 0 && !string.IsNullOrWhiteSpace(front) || !string.IsNullOrWhiteSpace(back) && stackId > 0)
        {
            var flashcard = new Flashcard() { Id = id, Front = front, Back = back, StackId = stackId };

            return _stackRepo.UpdateFlashcard(flashcard);
        }

        return false;
    }

    public bool DeleteFlashcard(int id)
    {
        return _stackRepo.DeleteFlashCard(id);
    }

    public bool DeleteStack(string name)
    {
        var stack = _stackRepo.GetStackByName(name);
        if (stack == null) return false;

        return _stackRepo.DeleteStack(stack.Id);
    }

    private FlashcardStackDTO StackToDTO(FlashcardStack stack)
    {
        return new FlashcardStackDTO()
        {
            Id = stack.Id,
            Name = stack.Name,
            Flashcards = stack.Flashcards
                .Select((f, i) => FlashcardToDto(f, i+1))
                .ToList()
        };
    }

    private FlashcardDTO FlashcardToDto(Flashcard flashcard, int viewId)
    {
        return new FlashcardDTO()
        {
            Id = flashcard.Id,
            ViewId = viewId,
            Front = flashcard.Front,
            Back = flashcard.Back
        };
    }
}