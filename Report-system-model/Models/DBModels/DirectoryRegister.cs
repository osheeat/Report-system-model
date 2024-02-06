using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("directory_register")]
public class DirectoryRegister
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Column("sap_code")]
    [MaxLength(500)] public string SAPCode { get; set; }
    
    [Column("directory_id")]
    [MaxLength(25)] public string DirectoryId { get; set; }
    public virtual Directory? VirtualDirectory { get; set; }
    
    [Column("encoding_language_id")]
    [MaxLength(25)] public string EncodingLanguageId { get; set; }
    public virtual EncodingLanguage? VirtualEncodingLanguage { get; set; }
    
    [Column("analytical_feature_id")]
    [MaxLength(200)] public string AnalyticalFeatureId { get; set; }
    public virtual AnalyticalFeature? VirtualAnalyticalFeature { get; set; }
    
    [Column("local_corporate_id")]
    [MaxLength(200)] public string LocalCorporateId { get; set; }
    public virtual LocalCorporate? VirtualLocalCorporate { get; set; }
    
    [Column("analytical_id")]
    [MaxLength(200)] public string AnalyticalId { get; set; }
    public virtual Analytical? VirtualAnalytical { get; set; }
    
    [Column("nsi_obj_id")]
    [MaxLength(200)] public string NsiObjId { get; set; }
    public virtual NsiObj? VirtualNsiObj { get; set; }
    
    [Column("source_table_in_dw_id")]
    [MaxLength(200)] public string SourceTableInDWId { get; set; }
    public virtual SourceTableInDW? VirtualSourceTableInDW{ get; set; }
    
    [Column("ksss_id")]
    [MaxLength(200)] public string KSSSId { get; set; }
    public virtual KSSS? VirtualKSSS{ get; set; }
    
    [Column("available_attributes")]
    public bool AvailableAttributes { get; set; }
    
    [Column("hierarchy_feature")]
    public bool HierarchyFeature { get; set; }
    
    [Column("mapping_code")]
    [MaxLength(200)] public string MappingCode { get; set; }

    [Column("comment")]
    [MaxLength(500)] public string Comment { get; set; }
}