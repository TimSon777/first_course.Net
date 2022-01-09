using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ui.Models
{
    public class SettingsScanningViewModel
    {
        [Required]
        [Url]
        [MaxLength(300)]
        [DisplayName("Домен")]
        public string Domain { get; set; }
        
        [Required]
        [Range(0, 100)]
        [DisplayName("Макс количество ссылок на странице")]
        public int MaxLinksInPage { get; set; }
        
        [Required]
        [Range(0, 5)]
        [DisplayName("Макс уровень сканирования")]
        public int MaxLevel { get; set; }
        
        public SettingsScanningViewModel(string domain, int maxLinksInPage, int maxLevel)
        {
            Domain = domain;
            MaxLinksInPage = maxLinksInPage;
            MaxLevel = maxLevel;
        }

        public SettingsScanningViewModel()
        { }
    }
}