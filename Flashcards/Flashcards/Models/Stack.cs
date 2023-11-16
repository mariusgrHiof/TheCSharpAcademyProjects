﻿namespace Flashcards.Models;

public class Stack
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Flashcard> Flashcards { get; set; }
}

