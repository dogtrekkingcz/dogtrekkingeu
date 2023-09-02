// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: google/type/postal_address.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Type {

  /// <summary>Holder for reflection information generated from google/type/postal_address.proto</summary>
  public static partial class PostalAddressReflection {

    #region Descriptor
    /// <summary>File descriptor for google/type/postal_address.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PostalAddressReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiBnb29nbGUvdHlwZS9wb3N0YWxfYWRkcmVzcy5wcm90bxILZ29vZ2xlLnR5",
            "cGUi/QEKDVBvc3RhbEFkZHJlc3MSEAoIcmV2aXNpb24YASABKAUSEwoLcmVn",
            "aW9uX2NvZGUYAiABKAkSFQoNbGFuZ3VhZ2VfY29kZRgDIAEoCRITCgtwb3N0",
            "YWxfY29kZRgEIAEoCRIUCgxzb3J0aW5nX2NvZGUYBSABKAkSGwoTYWRtaW5p",
            "c3RyYXRpdmVfYXJlYRgGIAEoCRIQCghsb2NhbGl0eRgHIAEoCRITCgtzdWJs",
            "b2NhbGl0eRgIIAEoCRIVCg1hZGRyZXNzX2xpbmVzGAkgAygJEhIKCnJlY2lw",
            "aWVudHMYCiADKAkSFAoMb3JnYW5pemF0aW9uGAsgASgJQngKD2NvbS5nb29n",
            "bGUudHlwZUISUG9zdGFsQWRkcmVzc1Byb3RvUAFaRmdvb2dsZS5nb2xhbmcu",
            "b3JnL2dlbnByb3RvL2dvb2dsZWFwaXMvdHlwZS9wb3N0YWxhZGRyZXNzO3Bv",
            "c3RhbGFkZHJlc3P4AQGiAgNHVFBiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Type.PostalAddress), global::Google.Type.PostalAddress.Parser, new[]{ "Revision", "RegionCode", "LanguageCode", "PostalCode", "SortingCode", "AdministrativeArea", "Locality", "Sublocality", "AddressLines", "Recipients", "Organization" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Represents a postal address, e.g. for postal delivery or payments addresses.
  /// Given a postal address, a postal service can deliver items to a premise, P.O.
  /// Box or similar.
  /// It is not intended to model geographical locations (roads, towns,
  /// mountains).
  ///
  /// In typical usage an address would be created via user input or from importing
  /// existing data, depending on the type of process.
  ///
  /// Advice on address input / editing:
  ///  - Use an i18n-ready address widget such as
  ///    https://github.com/google/libaddressinput)
  /// - Users should not be presented with UI elements for input or editing of
  ///   fields outside countries where that field is used.
  ///
  /// For more guidance on how to use this schema, please see:
  /// https://support.google.com/business/answer/6397478
  /// </summary>
  public sealed partial class PostalAddress : pb::IMessage<PostalAddress>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<PostalAddress> _parser = new pb::MessageParser<PostalAddress>(() => new PostalAddress());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<PostalAddress> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Type.PostalAddressReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PostalAddress() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PostalAddress(PostalAddress other) : this() {
      revision_ = other.revision_;
      regionCode_ = other.regionCode_;
      languageCode_ = other.languageCode_;
      postalCode_ = other.postalCode_;
      sortingCode_ = other.sortingCode_;
      administrativeArea_ = other.administrativeArea_;
      locality_ = other.locality_;
      sublocality_ = other.sublocality_;
      addressLines_ = other.addressLines_.Clone();
      recipients_ = other.recipients_.Clone();
      organization_ = other.organization_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public PostalAddress Clone() {
      return new PostalAddress(this);
    }

    /// <summary>Field number for the "revision" field.</summary>
    public const int RevisionFieldNumber = 1;
    private int revision_;
    /// <summary>
    /// The schema revision of the `PostalAddress`. This must be set to 0, which is
    /// the latest revision.
    ///
    /// All new revisions **must** be backward compatible with old revisions.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Revision {
      get { return revision_; }
      set {
        revision_ = value;
      }
    }

    /// <summary>Field number for the "region_code" field.</summary>
    public const int RegionCodeFieldNumber = 2;
    private string regionCode_ = "";
    /// <summary>
    /// Required. CLDR region code of the country/region of the address. This
    /// is never inferred and it is up to the user to ensure the value is
    /// correct. See http://cldr.unicode.org/ and
    /// http://www.unicode.org/cldr/charts/30/supplemental/territory_information.html
    /// for details. Example: "CH" for Switzerland.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string RegionCode {
      get { return regionCode_; }
      set {
        regionCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "language_code" field.</summary>
    public const int LanguageCodeFieldNumber = 3;
    private string languageCode_ = "";
    /// <summary>
    /// Optional. BCP-47 language code of the contents of this address (if
    /// known). This is often the UI language of the input form or is expected
    /// to match one of the languages used in the address' country/region, or their
    /// transliterated equivalents.
    /// This can affect formatting in certain countries, but is not critical
    /// to the correctness of the data and will never affect any validation or
    /// other non-formatting related operations.
    ///
    /// If this value is not known, it should be omitted (rather than specifying a
    /// possibly incorrect default).
    ///
    /// Examples: "zh-Hant", "ja", "ja-Latn", "en".
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string LanguageCode {
      get { return languageCode_; }
      set {
        languageCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "postal_code" field.</summary>
    public const int PostalCodeFieldNumber = 4;
    private string postalCode_ = "";
    /// <summary>
    /// Optional. Postal code of the address. Not all countries use or require
    /// postal codes to be present, but where they are used, they may trigger
    /// additional validation with other parts of the address (e.g. state/zip
    /// validation in the U.S.A.).
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string PostalCode {
      get { return postalCode_; }
      set {
        postalCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "sorting_code" field.</summary>
    public const int SortingCodeFieldNumber = 5;
    private string sortingCode_ = "";
    /// <summary>
    /// Optional. Additional, country-specific, sorting code. This is not used
    /// in most regions. Where it is used, the value is either a string like
    /// "CEDEX", optionally followed by a number (e.g. "CEDEX 7"), or just a number
    /// alone, representing the "sector code" (Jamaica), "delivery area indicator"
    /// (Malawi) or "post office indicator" (e.g. Côte d'Ivoire).
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string SortingCode {
      get { return sortingCode_; }
      set {
        sortingCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "administrative_area" field.</summary>
    public const int AdministrativeAreaFieldNumber = 6;
    private string administrativeArea_ = "";
    /// <summary>
    /// Optional. Highest administrative subdivision which is used for postal
    /// addresses of a country or region.
    /// For example, this can be a state, a province, an oblast, or a prefecture.
    /// Specifically, for Spain this is the province and not the autonomous
    /// community (e.g. "Barcelona" and not "Catalonia").
    /// Many countries don't use an administrative area in postal addresses. E.g.
    /// in Switzerland this should be left unpopulated.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string AdministrativeArea {
      get { return administrativeArea_; }
      set {
        administrativeArea_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "locality" field.</summary>
    public const int LocalityFieldNumber = 7;
    private string locality_ = "";
    /// <summary>
    /// Optional. Generally refers to the city/town portion of the address.
    /// Examples: US city, IT comune, UK post town.
    /// In regions of the world where localities are not well defined or do not fit
    /// into this structure well, leave locality empty and use address_lines.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Locality {
      get { return locality_; }
      set {
        locality_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "sublocality" field.</summary>
    public const int SublocalityFieldNumber = 8;
    private string sublocality_ = "";
    /// <summary>
    /// Optional. Sublocality of the address.
    /// For example, this can be neighborhoods, boroughs, districts.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Sublocality {
      get { return sublocality_; }
      set {
        sublocality_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "address_lines" field.</summary>
    public const int AddressLinesFieldNumber = 9;
    private static readonly pb::FieldCodec<string> _repeated_addressLines_codec
        = pb::FieldCodec.ForString(74);
    private readonly pbc::RepeatedField<string> addressLines_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// Unstructured address lines describing the lower levels of an address.
    ///
    /// Because values in address_lines do not have type information and may
    /// sometimes contain multiple values in a single field (e.g.
    /// "Austin, TX"), it is important that the line order is clear. The order of
    /// address lines should be "envelope order" for the country/region of the
    /// address. In places where this can vary (e.g. Japan), address_language is
    /// used to make it explicit (e.g. "ja" for large-to-small ordering and
    /// "ja-Latn" or "en" for small-to-large). This way, the most specific line of
    /// an address can be selected based on the language.
    ///
    /// The minimum permitted structural representation of an address consists
    /// of a region_code with all remaining information placed in the
    /// address_lines. It would be possible to format such an address very
    /// approximately without geocoding, but no semantic reasoning could be
    /// made about any of the address components until it was at least
    /// partially resolved.
    ///
    /// Creating an address only containing a region_code and address_lines, and
    /// then geocoding is the recommended way to handle completely unstructured
    /// addresses (as opposed to guessing which parts of the address should be
    /// localities or administrative areas).
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> AddressLines {
      get { return addressLines_; }
    }

    /// <summary>Field number for the "recipients" field.</summary>
    public const int RecipientsFieldNumber = 10;
    private static readonly pb::FieldCodec<string> _repeated_recipients_codec
        = pb::FieldCodec.ForString(82);
    private readonly pbc::RepeatedField<string> recipients_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// Optional. The recipient at the address.
    /// This field may, under certain circumstances, contain multiline information.
    /// For example, it might contain "care of" information.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<string> Recipients {
      get { return recipients_; }
    }

    /// <summary>Field number for the "organization" field.</summary>
    public const int OrganizationFieldNumber = 11;
    private string organization_ = "";
    /// <summary>
    /// Optional. The name of the organization at the address.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Organization {
      get { return organization_; }
      set {
        organization_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as PostalAddress);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(PostalAddress other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Revision != other.Revision) return false;
      if (RegionCode != other.RegionCode) return false;
      if (LanguageCode != other.LanguageCode) return false;
      if (PostalCode != other.PostalCode) return false;
      if (SortingCode != other.SortingCode) return false;
      if (AdministrativeArea != other.AdministrativeArea) return false;
      if (Locality != other.Locality) return false;
      if (Sublocality != other.Sublocality) return false;
      if(!addressLines_.Equals(other.addressLines_)) return false;
      if(!recipients_.Equals(other.recipients_)) return false;
      if (Organization != other.Organization) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Revision != 0) hash ^= Revision.GetHashCode();
      if (RegionCode.Length != 0) hash ^= RegionCode.GetHashCode();
      if (LanguageCode.Length != 0) hash ^= LanguageCode.GetHashCode();
      if (PostalCode.Length != 0) hash ^= PostalCode.GetHashCode();
      if (SortingCode.Length != 0) hash ^= SortingCode.GetHashCode();
      if (AdministrativeArea.Length != 0) hash ^= AdministrativeArea.GetHashCode();
      if (Locality.Length != 0) hash ^= Locality.GetHashCode();
      if (Sublocality.Length != 0) hash ^= Sublocality.GetHashCode();
      hash ^= addressLines_.GetHashCode();
      hash ^= recipients_.GetHashCode();
      if (Organization.Length != 0) hash ^= Organization.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Revision != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Revision);
      }
      if (RegionCode.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(RegionCode);
      }
      if (LanguageCode.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(LanguageCode);
      }
      if (PostalCode.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(PostalCode);
      }
      if (SortingCode.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(SortingCode);
      }
      if (AdministrativeArea.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(AdministrativeArea);
      }
      if (Locality.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Locality);
      }
      if (Sublocality.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Sublocality);
      }
      addressLines_.WriteTo(output, _repeated_addressLines_codec);
      recipients_.WriteTo(output, _repeated_recipients_codec);
      if (Organization.Length != 0) {
        output.WriteRawTag(90);
        output.WriteString(Organization);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Revision != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Revision);
      }
      if (RegionCode.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(RegionCode);
      }
      if (LanguageCode.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(LanguageCode);
      }
      if (PostalCode.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(PostalCode);
      }
      if (SortingCode.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(SortingCode);
      }
      if (AdministrativeArea.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(AdministrativeArea);
      }
      if (Locality.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(Locality);
      }
      if (Sublocality.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Sublocality);
      }
      addressLines_.WriteTo(ref output, _repeated_addressLines_codec);
      recipients_.WriteTo(ref output, _repeated_recipients_codec);
      if (Organization.Length != 0) {
        output.WriteRawTag(90);
        output.WriteString(Organization);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Revision != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Revision);
      }
      if (RegionCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RegionCode);
      }
      if (LanguageCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(LanguageCode);
      }
      if (PostalCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PostalCode);
      }
      if (SortingCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SortingCode);
      }
      if (AdministrativeArea.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AdministrativeArea);
      }
      if (Locality.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Locality);
      }
      if (Sublocality.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Sublocality);
      }
      size += addressLines_.CalculateSize(_repeated_addressLines_codec);
      size += recipients_.CalculateSize(_repeated_recipients_codec);
      if (Organization.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Organization);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(PostalAddress other) {
      if (other == null) {
        return;
      }
      if (other.Revision != 0) {
        Revision = other.Revision;
      }
      if (other.RegionCode.Length != 0) {
        RegionCode = other.RegionCode;
      }
      if (other.LanguageCode.Length != 0) {
        LanguageCode = other.LanguageCode;
      }
      if (other.PostalCode.Length != 0) {
        PostalCode = other.PostalCode;
      }
      if (other.SortingCode.Length != 0) {
        SortingCode = other.SortingCode;
      }
      if (other.AdministrativeArea.Length != 0) {
        AdministrativeArea = other.AdministrativeArea;
      }
      if (other.Locality.Length != 0) {
        Locality = other.Locality;
      }
      if (other.Sublocality.Length != 0) {
        Sublocality = other.Sublocality;
      }
      addressLines_.Add(other.addressLines_);
      recipients_.Add(other.recipients_);
      if (other.Organization.Length != 0) {
        Organization = other.Organization;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Revision = input.ReadInt32();
            break;
          }
          case 18: {
            RegionCode = input.ReadString();
            break;
          }
          case 26: {
            LanguageCode = input.ReadString();
            break;
          }
          case 34: {
            PostalCode = input.ReadString();
            break;
          }
          case 42: {
            SortingCode = input.ReadString();
            break;
          }
          case 50: {
            AdministrativeArea = input.ReadString();
            break;
          }
          case 58: {
            Locality = input.ReadString();
            break;
          }
          case 66: {
            Sublocality = input.ReadString();
            break;
          }
          case 74: {
            addressLines_.AddEntriesFrom(input, _repeated_addressLines_codec);
            break;
          }
          case 82: {
            recipients_.AddEntriesFrom(input, _repeated_recipients_codec);
            break;
          }
          case 90: {
            Organization = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Revision = input.ReadInt32();
            break;
          }
          case 18: {
            RegionCode = input.ReadString();
            break;
          }
          case 26: {
            LanguageCode = input.ReadString();
            break;
          }
          case 34: {
            PostalCode = input.ReadString();
            break;
          }
          case 42: {
            SortingCode = input.ReadString();
            break;
          }
          case 50: {
            AdministrativeArea = input.ReadString();
            break;
          }
          case 58: {
            Locality = input.ReadString();
            break;
          }
          case 66: {
            Sublocality = input.ReadString();
            break;
          }
          case 74: {
            addressLines_.AddEntriesFrom(ref input, _repeated_addressLines_codec);
            break;
          }
          case 82: {
            recipients_.AddEntriesFrom(ref input, _repeated_recipients_codec);
            break;
          }
          case 90: {
            Organization = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
