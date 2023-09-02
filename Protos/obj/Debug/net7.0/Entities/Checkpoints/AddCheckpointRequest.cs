// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Entities/Checkpoints/AddCheckpointRequest.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Protos.Checkpoints.AddCheckpoint {

  /// <summary>Holder for reflection information generated from Entities/Checkpoints/AddCheckpointRequest.proto</summary>
  public static partial class AddCheckpointRequestReflection {

    #region Descriptor
    /// <summary>File descriptor for Entities/Checkpoints/AddCheckpointRequest.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AddCheckpointRequestReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ci9FbnRpdGllcy9DaGVja3BvaW50cy9BZGRDaGVja3BvaW50UmVxdWVzdC5w",
            "cm90bxINYWRkY2hlY2twb2ludBoaZ29vZ2xlL3R5cGUvZGF0ZXRpbWUucHJv",
            "dG8aGGdvb2dsZS90eXBlL2xhdGxuZy5wcm90byLTAQoUQWRkQ2hlY2twb2lu",
            "dFJlcXVlc3QSEAoIQWN0aW9uSWQYASABKAkSFAoMQ2hlY2twb2ludElkGAIg",
            "ASgJEgwKBE5hbWUYAyABKAkSEwoLRGVzY3JpcHRpb24YBCABKAkSLQoOQ2hl",
            "Y2twb2ludFRpbWUYBSABKAsyFS5nb29nbGUudHlwZS5EYXRlVGltZRIMCgRE",
            "YXRhGAYgASgJEiUKCFBvc2l0aW9uGAcgASgLMhMuZ29vZ2xlLnR5cGUuTGF0",
            "TG5nEgwKBE5vdGUYCCABKAlCI6oCIFByb3Rvcy5DaGVja3BvaW50cy5BZGRD",
            "aGVja3BvaW50YgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Type.DatetimeReflection.Descriptor, global::Google.Type.LatlngReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Protos.Checkpoints.AddCheckpoint.AddCheckpointRequest), global::Protos.Checkpoints.AddCheckpoint.AddCheckpointRequest.Parser, new[]{ "ActionId", "CheckpointId", "Name", "Description", "CheckpointTime", "Data", "Position", "Note" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class AddCheckpointRequest : pb::IMessage<AddCheckpointRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<AddCheckpointRequest> _parser = new pb::MessageParser<AddCheckpointRequest>(() => new AddCheckpointRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<AddCheckpointRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Protos.Checkpoints.AddCheckpoint.AddCheckpointRequestReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AddCheckpointRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AddCheckpointRequest(AddCheckpointRequest other) : this() {
      actionId_ = other.actionId_;
      checkpointId_ = other.checkpointId_;
      name_ = other.name_;
      description_ = other.description_;
      checkpointTime_ = other.checkpointTime_ != null ? other.checkpointTime_.Clone() : null;
      data_ = other.data_;
      position_ = other.position_ != null ? other.position_.Clone() : null;
      note_ = other.note_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public AddCheckpointRequest Clone() {
      return new AddCheckpointRequest(this);
    }

    /// <summary>Field number for the "ActionId" field.</summary>
    public const int ActionIdFieldNumber = 1;
    private string actionId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ActionId {
      get { return actionId_; }
      set {
        actionId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "CheckpointId" field.</summary>
    public const int CheckpointIdFieldNumber = 2;
    private string checkpointId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CheckpointId {
      get { return checkpointId_; }
      set {
        checkpointId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Name" field.</summary>
    public const int NameFieldNumber = 3;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Description" field.</summary>
    public const int DescriptionFieldNumber = 4;
    private string description_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Description {
      get { return description_; }
      set {
        description_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "CheckpointTime" field.</summary>
    public const int CheckpointTimeFieldNumber = 5;
    private global::Google.Type.DateTime checkpointTime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Type.DateTime CheckpointTime {
      get { return checkpointTime_; }
      set {
        checkpointTime_ = value;
      }
    }

    /// <summary>Field number for the "Data" field.</summary>
    public const int DataFieldNumber = 6;
    private string data_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Position" field.</summary>
    public const int PositionFieldNumber = 7;
    private global::Google.Type.LatLng position_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Google.Type.LatLng Position {
      get { return position_; }
      set {
        position_ = value;
      }
    }

    /// <summary>Field number for the "Note" field.</summary>
    public const int NoteFieldNumber = 8;
    private string note_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Note {
      get { return note_; }
      set {
        note_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as AddCheckpointRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(AddCheckpointRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ActionId != other.ActionId) return false;
      if (CheckpointId != other.CheckpointId) return false;
      if (Name != other.Name) return false;
      if (Description != other.Description) return false;
      if (!object.Equals(CheckpointTime, other.CheckpointTime)) return false;
      if (Data != other.Data) return false;
      if (!object.Equals(Position, other.Position)) return false;
      if (Note != other.Note) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ActionId.Length != 0) hash ^= ActionId.GetHashCode();
      if (CheckpointId.Length != 0) hash ^= CheckpointId.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Description.Length != 0) hash ^= Description.GetHashCode();
      if (checkpointTime_ != null) hash ^= CheckpointTime.GetHashCode();
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      if (position_ != null) hash ^= Position.GetHashCode();
      if (Note.Length != 0) hash ^= Note.GetHashCode();
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
      if (ActionId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ActionId);
      }
      if (CheckpointId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CheckpointId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (Description.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Description);
      }
      if (checkpointTime_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(CheckpointTime);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Data);
      }
      if (position_ != null) {
        output.WriteRawTag(58);
        output.WriteMessage(Position);
      }
      if (Note.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Note);
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
      if (ActionId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ActionId);
      }
      if (CheckpointId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CheckpointId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (Description.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Description);
      }
      if (checkpointTime_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(CheckpointTime);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(Data);
      }
      if (position_ != null) {
        output.WriteRawTag(58);
        output.WriteMessage(Position);
      }
      if (Note.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Note);
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
      if (ActionId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ActionId);
      }
      if (CheckpointId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CheckpointId);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Description.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Description);
      }
      if (checkpointTime_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CheckpointTime);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Data);
      }
      if (position_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Position);
      }
      if (Note.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Note);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(AddCheckpointRequest other) {
      if (other == null) {
        return;
      }
      if (other.ActionId.Length != 0) {
        ActionId = other.ActionId;
      }
      if (other.CheckpointId.Length != 0) {
        CheckpointId = other.CheckpointId;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Description.Length != 0) {
        Description = other.Description;
      }
      if (other.checkpointTime_ != null) {
        if (checkpointTime_ == null) {
          CheckpointTime = new global::Google.Type.DateTime();
        }
        CheckpointTime.MergeFrom(other.CheckpointTime);
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
      if (other.position_ != null) {
        if (position_ == null) {
          Position = new global::Google.Type.LatLng();
        }
        Position.MergeFrom(other.Position);
      }
      if (other.Note.Length != 0) {
        Note = other.Note;
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
          case 10: {
            ActionId = input.ReadString();
            break;
          }
          case 18: {
            CheckpointId = input.ReadString();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 34: {
            Description = input.ReadString();
            break;
          }
          case 42: {
            if (checkpointTime_ == null) {
              CheckpointTime = new global::Google.Type.DateTime();
            }
            input.ReadMessage(CheckpointTime);
            break;
          }
          case 50: {
            Data = input.ReadString();
            break;
          }
          case 58: {
            if (position_ == null) {
              Position = new global::Google.Type.LatLng();
            }
            input.ReadMessage(Position);
            break;
          }
          case 66: {
            Note = input.ReadString();
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
          case 10: {
            ActionId = input.ReadString();
            break;
          }
          case 18: {
            CheckpointId = input.ReadString();
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 34: {
            Description = input.ReadString();
            break;
          }
          case 42: {
            if (checkpointTime_ == null) {
              CheckpointTime = new global::Google.Type.DateTime();
            }
            input.ReadMessage(CheckpointTime);
            break;
          }
          case 50: {
            Data = input.ReadString();
            break;
          }
          case 58: {
            if (position_ == null) {
              Position = new global::Google.Type.LatLng();
            }
            input.ReadMessage(Position);
            break;
          }
          case 66: {
            Note = input.ReadString();
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
