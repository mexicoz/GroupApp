﻿using System.ComponentModel.DataAnnotations;

namespace GroupApp.Models
{
	public class Adress
	{
		[Key]
		public int Id { get; set; }
		public string Street { get; set; }
		public string Sity { get; set; }
		public string State { get; set; }
	}
}
