﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace memoseeds.Models.Entities
{
    [Table("completions")]
    public class Completion
    {
        [Key]
        [Column("id")]
        public int CompletionId { get; set; }

        [Column("collector")]
        public int CollectorId { get; set; }
        public Collector Collector { get; set; }

        [Column("type")]
        public int TypeId { get; set; }
        public Type Type { get; set; }

        [Required]
        [Column("success")]
        public int NumSuccess { get; set; }

        [Required]
        [Column("attempt")]
        public int NumAttempt { get; set; }
    }
}