﻿using System.ComponentModel.DataAnnotations.Schema;

namespace UserCRUD.Domain;

public class BaseModel
{
    [Column("id")]
    public long Id { get; set; }
}