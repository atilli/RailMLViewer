//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.0.0.0.
namespace Schemas.Gml
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    
    
    /// <summary>
    /// <para>A LineString is a special curve that consists of a single segment with linear interpolation. It is defined by two or more coordinate tuples, with linear interpolation between them. The number of direct positions in the list shall be at least two.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("LineStringType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.LineTypeCoordinate))]
    public partial class LineStringType : AbstractCurveType
    {
        
        [System.Xml.Serialization.XmlElementAttribute("pos", Namespace="https://www.railml.org/schemas/3.1/gml")]
        public DirectPositionType Pos { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("posList", Namespace="https://www.railml.org/schemas/3.1/gml")]
        public DirectPositionListType PosList { get; set; }
    }
    
    /// <summary>
    /// <para>gml:AbstractCurveType is an abstraction of a curve to support the different levels of complexity. The curve may always be viewed as a geometric primitive, i.e. is continuous.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("AbstractCurveType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.LineTypeCoordinate))]
    public abstract partial class AbstractCurveType : AbstractGeometricPrimitiveType
    {
    }
    
    /// <summary>
    /// <para>gml:AbstractGeometricPrimitiveType is the abstract root type of the geometric primitives. A geometric primitive is a geometric object that is not decomposed further into other primitives in the system. All primitives are oriented in the direction implied by the sequence of their coordinate tuples.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("AbstractGeometricPrimitiveType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.LineTypeCoordinate))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.PointTypeCoordinate))]
    public abstract partial class AbstractGeometricPrimitiveType : AbstractGeometryType
    {
    }
    
    /// <summary>
    /// <para>All geometry elements are derived directly or indirectly from this abstract supertype. A geometry element may have an identifying attribute (gml:id), one or more names (elements identifier and name) and a description (elements description and descriptionReference) . It may be associated with a spatial reference system (attribute group gml:SRSReferenceGroup).</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("AbstractGeometryType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometricPrimitiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.LineTypeCoordinate))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.PointTypeCoordinate))]
    public abstract partial class AbstractGeometryType : AbstractGMLType, ISRSReferenceGroup
    {
        
        [System.Xml.Serialization.XmlAttributeAttribute("srsDimension", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SrsDimension { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("srsName", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SrsName { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("axisLabels", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AxisLabels { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("uomLabels", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UomLabels { get; set; }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("AbstractGMLType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractCurveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometricPrimitiveType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AbstractGeometryType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LineStringType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.LineTypeCoordinate))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PointType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.PointTypeCoordinate))]
    public abstract partial class AbstractGMLType : IStandardObjectProperties
    {
        
        [System.Xml.Serialization.XmlElementAttribute("description", Namespace="https://www.railml.org/schemas/3.1/gml")]
        public StringOrRefType Description { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("descriptionReference", Namespace="https://www.railml.org/schemas/3.1/gml")]
        public ReferenceType DescriptionReference { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<CodeType> _name;
        
        [System.Xml.Serialization.XmlElementAttribute("name", Namespace="https://www.railml.org/schemas/3.1/gml")]
        public System.Collections.ObjectModel.Collection<CodeType> Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                this._name = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Name-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Name collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NameSpecified
        {
            get
            {
                return (this.Name.Count != 0);
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="AbstractGMLType" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="AbstractGMLType" /> class.</para>
        /// </summary>
        public AbstractGMLType()
        {
            this._name = new System.Collections.ObjectModel.Collection<CodeType>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("identifier", Namespace="https://www.railml.org/schemas/3.1/gml")]
        public CodeWithAuthorityType Identifier { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("id", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Id { get; set; }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    public partial interface IStandardObjectProperties
    {
        
        StringOrRefType Description
        {
            get;
            set;
        }
        
        ReferenceType DescriptionReference
        {
            get;
            set;
        }
        
        System.Collections.ObjectModel.Collection<CodeType> Name
        {
            get;
        }
        
        CodeWithAuthorityType Identifier
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// <para>deprecated</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("StringOrRefType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StringOrRefType : IAssociationAttributeGroup
    {
        
        /// <summary>
        /// <para xml:lang="de">Ruft den Text ab oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("nilReason", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NilReason { get; set; }
    }
    
    /// <summary>
    /// <para>XLink components are the standard method to support hypertext referencing in XML. An XML Schema attribute group, gml:AssociationAttributeGroup, is provided to support the use of Xlinks as the method for indicating the value of a property by reference in a uniform manner in GML.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    public partial interface IAssociationAttributeGroup
    {
        
        string NilReason
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// <para>gml:ReferenceType is intended to be used in application schemas directly, if a property element shall use a "by-reference only" encoding.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("ReferenceType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReferenceType : IOwnershipAttributeGroup, IAssociationAttributeGroup
    {
        
        [System.Xml.Serialization.XmlAttributeAttribute("owns", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool Owns { get; set; }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Owns-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Owns property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OwnsSpecified { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("nilReason", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NilReason { get; set; }
    }
    
    /// <summary>
    /// <para>Encoding a GML property inline vs. by-reference shall not imply anything about the "ownership" of the contained or referenced GML Object, i.e. the encoding style shall not imply any "deep-copy" or "deep-delete" semantics. To express ownership over the contained or referenced GML Object, the gml:OwnershipAttributeGroup attribute group may be added to object-valued property elements. If the attribute group is not part of the content model of such a property element, then the value may not be "owned".
    ///When the value of the owns attribute is "true", the existence of inline or referenced object(s) depends upon the existence of the parent object.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    public partial interface IOwnershipAttributeGroup
    {
        
        bool Owns
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// <para>gml:CodeType is a generalized type to be used for a term, keyword or name.
    ///It adds a XML attribute codeSpace to a term, where the value of the codeSpace attribute (if present) shall indicate a dictionary, thesaurus, classification scheme, authority, or pattern for the term.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("CodeType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CodeWithAuthorityType))]
    public partial class CodeType
    {
        
        /// <summary>
        /// <para xml:lang="de">Ruft den Text ab oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("codeSpace", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CodeSpace { get; set; }
    }
    
    /// <summary>
    /// <para>gml:CodeWithAuthorityType requires that the codeSpace attribute is provided in an instance.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("CodeWithAuthorityType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CodeWithAuthorityType : CodeType
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    public partial interface ISRSReferenceGroup : ISRSInformationGroup
    {
        
        string SrsDimension
        {
            get;
            set;
        }
        
        string SrsName
        {
            get;
            set;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    public partial interface ISRSInformationGroup
    {
        
        string AxisLabels
        {
            get;
            set;
        }
        
        string UomLabels
        {
            get;
            set;
        }
    }
    
    /// <summary>
    /// <para>Direct position instances hold the coordinates for a position within some coordinate reference system (CRS). Since direct positions, as data types, will often be included in larger objects (such as geometry elements) that have references to CRS, the srsName attribute will in general be missing, if this particular direct position is included in a larger element with such a reference to a CRS. In this case, the CRS is implicitly assumed to take on the value of the containing object's CRS.
    ///if no srsName attribute is given, the CRS shall be specified as part of the larger context this geometry element is part of, typically a geometric object like a point, curve, etc.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("DirectPositionType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DirectPositionType : ISRSReferenceGroup
    {
        
        /// <summary>
        /// <para xml:lang="de">Ruft den Text ab oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("srsDimension", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SrsDimension { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("srsName", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SrsName { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("axisLabels", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AxisLabels { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("uomLabels", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UomLabels { get; set; }
    }
    
    /// <summary>
    /// <para>posList instances (and other instances with the content model specified by DirectPositionListType) hold the coordinates for a sequence of direct positions within the same coordinate reference system (CRS).
    ///if no srsName attribute is given, the CRS shall be specified as part of the larger context this geometry element is part of, typically a geometric object like a point, curve, etc. 
    ///The optional attribute count specifies the number of direct positions in the list. If the attribute count is present then the attribute srsDimension shall be present, too.
    ///The number of entries in the list is equal to the product of the dimensionality of the coordinate reference system (i.e. it is a derived value of the coordinate reference system definition) and the number of direct positions.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("DirectPositionListType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DirectPositionListType : ISRSReferenceGroup
    {
        
        /// <summary>
        /// <para xml:lang="de">Ruft den Text ab oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("count", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Count { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("srsDimension", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SrsDimension { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("srsName", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SrsName { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("axisLabels", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AxisLabels { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("uomLabels", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UomLabels { get; set; }
    }
    
    /// <summary>
    /// <para>A Point is defined by a single coordinate tuple. The direct position of a point is specified by the pos element which is of type DirectPositionType.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("PointType", Namespace="https://www.railml.org/schemas/3.1/gml")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Schemas.PointTypeCoordinate))]
    public partial class PointType : AbstractGeometricPrimitiveType
    {
        
        [System.Xml.Serialization.XmlElementAttribute("pos", Namespace="https://www.railml.org/schemas/3.1/gml")]
        public DirectPositionType Pos { get; set; }
    }
}