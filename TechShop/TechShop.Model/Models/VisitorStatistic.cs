namespace TechShop.Model.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="VisitorStatistic" />
    /// </summary>
    [Table("VisitorStatistics")]
    public class VisitorStatistic
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        [Key]
        public Guid ID { set; get; }

        /// <summary>
        /// Gets or sets the VisitedDate
        /// </summary>
        [Required]
        public DateTime VisitedDate { set; get; }

        /// <summary>
        /// Gets or sets the IPAddress
        /// </summary>
        [MaxLength(50)]
        public string IPAddress { set; get; }
    }
}
