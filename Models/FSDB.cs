
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class Fs
{

    private FsFsCompetition fsCompetitionField;

    private decimal versionField;

    private string commentField;

    /// <remarks/>
    public FsFsCompetition FsCompetition
    {
        get
        {
            return this.fsCompetitionField;
        }
        set
        {
            this.fsCompetitionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string comment
    {
        get
        {
            return this.commentField;
        }
        set
        {
            this.commentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class FsFsCompetition
{

    private FsFsCompetitionFsParticipant[] fsParticipantsField;

    private byte idField;

    private string nameField;

    private string locationField;

    private string fromField;

    private string toField;

    private byte utc_offsetField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("FsParticipant", IsNullable = false)]
    public FsFsCompetitionFsParticipant[] FsParticipants
    {
        get
        {
            return this.fsParticipantsField;
        }
        set
        {
            this.fsParticipantsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string location
    {
        get
        {
            return this.locationField;
        }
        set
        {
            this.locationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string from
    {
        get
        {
            return this.fromField;
        }
        set
        {
            this.fromField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string to
    {
        get
        {
            return this.toField;
        }
        set
        {
            this.toField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte utc_offset
    {
        get
        {
            return this.utc_offsetField;
        }
        set
        {
            this.utc_offsetField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class FsFsCompetitionFsParticipant
{

    private FsFsCompetitionFsParticipantFsCustomAttribute[] fsCustomAttributesField;

    private byte idField;

    private string nameField;

    private string birthdayField;

    private string gliderField;

    private string fai_licenceField;

    private byte femaleField;

    private string nat_code_3166_a3Field;

    private string sponsorField;

    private string cIVLIDField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("FsCustomAttribute", IsNullable = false)]
    public FsFsCompetitionFsParticipantFsCustomAttribute[] FsCustomAttributes
    {
        get
        {
            return this.fsCustomAttributesField;
        }
        set
        {
            this.fsCustomAttributesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string birthday
    {
        get
        {
            return this.birthdayField;
        }
        set
        {
            this.birthdayField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string glider
    {
        get
        {
            return this.gliderField;
        }
        set
        {
            this.gliderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fai_licence
    {
        get
        {
            return this.fai_licenceField;
        }
        set
        {
            this.fai_licenceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte female
    {
        get
        {
            return this.femaleField;
        }
        set
        {
            this.femaleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string nat_code_3166_a3
    {
        get
        {
            return this.nat_code_3166_a3Field;
        }
        set
        {
            this.nat_code_3166_a3Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string sponsor
    {
        get
        {
            return this.sponsorField;
        }
        set
        {
            this.sponsorField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CIVLID
    {
        get
        {
            return this.cIVLIDField;
        }
        set
        {
            this.cIVLIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class FsFsCompetitionFsParticipantFsCustomAttribute
{

    private string nameField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}