﻿using Flashcards.Domain.Entities;
using System.Collections.Generic;

namespace Flashcards.Domain.DTO
{
    public class StudySessionDTO
    {
        public DateTime Date { get; set; }
        public int Score { get; set; }
    }
}
