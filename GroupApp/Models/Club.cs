﻿using GroupApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupApp.Models
{
	public class Club
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		
		[ForeignKey("Address")]
		public int AdressId { get; set; }
		public Adress Adress { get; set; }
		public ClubCategory ClubCategory { get; set; }

		[ForeignKey("AppUser")]
		public int? AppUserId { get; set; }
		public AppUser? AppUser { get; set; }
	}
}
