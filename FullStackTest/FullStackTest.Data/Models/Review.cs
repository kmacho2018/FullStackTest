// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FullStackTest.Data.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? MovieId { get; set; }

    public string Review1 { get; set; }

    public int? Rating { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Movie Movie { get; set; }
}