/*<FILE_LICENSE>
* NFX (.NET Framework Extension) Unistack Library
* Copyright 2003-2018 Agnicore Inc. portions ITAdapter Corp. Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
</FILE_LICENSE>*/


/* NFX by ITAdapter
 * Originated: 2006.01
 * Revision: NFX 0.3  2009.10.12
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

using NFX.Time;
using NFX.Log.Destinations;
using NFX.Serialization.JSON;
using NFX.Serialization.BSON;

namespace NFX.Log
{
  /// <summary>
  /// Represents a Log message
  /// </summary>
  [Serializable]
  [BSONSerializable("A05AEE0F-A33C-4B1D-AA45-CDEAF894A095")]
  public sealed class Message : IArchiveLoggable
  {
    public const string BSON_FLD_RELATED_TO = "rel";
    public const string BSON_FLD_TYPE = "tp";
    public const string BSON_FLD_SOURCE = "src";
    public const string BSON_FLD_TIMESTAMP = "time";
    public const string BSON_FLD_HOST = "host";
    public const string BSON_FLD_FROM = "from";
    public const string BSON_FLD_TOPIC = "top";
    public const string BSON_FLD_TEXT = "text";
    public const string BSON_FLD_PARAMETERS = "prms";
    public const string BSON_FLD_EXCEPTION = "exc";
    public const string BSON_FLD_ARCHIVE_DIMENSIONS = "arc";
    public const string BSON_FLD_CHANNEL = "chan";

    public static string DefaultHostName;

    #region Private Fields
    private Guid m_Guid;
    private Guid m_RelatedTo;
    private MessageType m_Type;
    private int m_Source;
    private DateTime m_TimeStamp;
    private string m_Host;
    private string m_From;
    private string m_Topic;
    private string m_Text;
    private string m_Parameters;
    private Exception m_Exception;
    private string m_ArchiveDimensions;
    private string m_Channel;
    #endregion

    #region Properties

    /// <summary>
    /// Returns global unique identifier for this particular message
    /// </summary>
    public Guid Guid
    {
      get { return m_Guid; }
    }

    /// <summary>
    /// Gets/Sets global unique identifier of a message that this message is related to.
    /// No referential integrity check is performed
    /// </summary>
    public Guid RelatedTo
    {
      get { return m_RelatedTo; }
      set { m_RelatedTo = value; }
    }

    /// <summary>
    /// Gets/Sets message type, such as: Info/Warning/Error etc...
    /// </summary>
    public MessageType Type
    {
      get { return m_Type; }
      set { m_Type = value; }
    }

    /// <summary>
    /// Gets/Sets message source line number/tracepoint#, this is used in conjunction with From
    /// </summary>
    public int Source
    {
      get { return m_Source; }
      set { m_Source = value; }
    }

    /// <summary>
    /// Gets/Sets timestamp when message was generated
    /// </summary>
    public DateTime TimeStamp
    {
      get { return m_TimeStamp; }
      set { m_TimeStamp = value; }
    }

    /// <summary>
    /// Gets/Sets host name that generated the message
    /// </summary>
    public string Host
    {
      get { return m_Host ?? string.Empty; }
      set { m_Host = value; }
    }


    /// <summary>
    /// Gets/Sets logical component ID, such as: class name, method name, process instance, that generated the message.
    /// This field is used in the scope of Topic
    /// </summary>
    public string From
    {
      get { return m_From ?? string.Empty; }
      set { m_From = value; }
    }

    /// <summary>
    /// Gets/Sets a message topic/relation - the name of software concern within the big app, i.e. "Database" or "Security"
    /// </summary>
    public string Topic
    {
      get { return m_Topic ?? string.Empty; }
      set { m_Topic = value; }
    }

    /// <summary>
    /// Gets/Sets an unstructured message text, the emitting component name must be in From field, not in text.
    /// Note about logging errors. Use caught exception.ToMessageWithType() method, then attach the caught exception as Exception property
    /// </summary>
    public string Text
    {
      get { return m_Text ?? string.Empty; }
      set { m_Text = value; }
    }

    /// <summary>
    /// Gets/Sets a structured parameter bag, this may be used for additional debug info like source file name, additional context etc.
    /// </summary>
    public string Parameters
    {
      get { return m_Parameters ?? string.Empty; }
      set { m_Parameters = value; }
    }

    /// <summary>
    /// Gets/Sets exception associated with message.
    /// Set this property EVEN IF the name/text of exception is already included in Text as log destinations may elect to dump the whole stack trace
    /// </summary>
    public Exception Exception
    {
      get { return m_Exception; }
      set { m_Exception = value; }
    }

    /// <summary>
    /// Gets/Sets archive dimension content for later retrieval of messages by key, i.e. a user ID may be used.
    /// In most cases JSON or Laconic content is stored, the format depends on a concrete system
    /// </summary>
    public string ArchiveDimensions
    {
      get { return m_ArchiveDimensions ?? string.Empty; }
      set { m_ArchiveDimensions = value; }
    }

    /// <summary>
    /// Gets/Sets logical partition for messages. This property is usually used in Archive for splitting destinations
    /// </summary>
    public string Channel
    {
      get { return m_Channel ?? string.Empty; }
      set { m_Channel = value; }
    }

    #endregion

    [NFX.Serialization.Slim.SlimDeserializationCtorSkip]
    public Message()
    {
      m_Guid = Guid.NewGuid();
      m_Host = Message.DefaultHostName ?? System.Environment.MachineName;
      m_TimeStamp = App.Instance.Log.LocalizedTime;
    }

    /// <summary>
    /// Creates message with Parameters supplanted with caller file name and line #
    /// </summary>
    public Message(object pars, [CallerFilePath] string file = null, [CallerLineNumber] int line = 0) : this()
    {
      SetParamsAsObject(FormatCallerParams(pars, file, line));
      Source = line;
    }

    public override string ToString()
    {
      return "{0}/{1}, {2}, {3}, {4}, {5}, {6}, {7}".Args(
                           m_Type,
                           m_Source,
                           m_TimeStamp,
                           Host,
                           From,
                           Topic,
                           Text,
                           Exception != null ? Exception.ToString() : string.Empty);
    }

    /// <summary>
    /// Supplants the from string with caller as JSON string
    /// </summary>
    public static object FormatCallerParams(object pars,
                                            [CallerFilePath]  string file = null,
                                            [CallerLineNumber]int line = 0)
    {
      if (pars == null)
        return new
        {
          clrF = file.IsNotNullOrWhiteSpace() ? Path.GetFileName(file) : null,
          clrL = line,
        };
      else
        return new
        {
          clrF = file.IsNotNullOrWhiteSpace() ? Path.GetFileName(file) : null,
          clrL = line,
          p = pars
        };
    }

    public Message SetParamsAsObject(object p)
    {
      if (p == null)
        m_Parameters = null;
      else
        m_Parameters = p.ToJSON(JSONWritingOptions.CompactASCII);

      return this;
    }

    public Message Clone()
    {
      return new Message
      {
        m_Guid = m_Guid,
        m_RelatedTo = m_RelatedTo,
        m_Type = m_Type,
        m_Source = m_Source,
        m_TimeStamp = m_TimeStamp,
        m_Host = m_Host,
        m_From = m_From,
        m_Topic = m_Topic,
        m_Text = m_Text,
        m_Parameters = m_Parameters,
        m_Exception = m_Exception,
        m_ArchiveDimensions = m_ArchiveDimensions,
        m_Channel = m_Channel
      };
    }


    #region BSON Serialization
    public bool IsKnownTypeForBSONDeserialization(Type type)
    {
      return type == typeof(WrappedException);
    }

    public void SerializeToBSON(BSONSerializer serializer, BSONDocument doc, IBSONSerializable parent, ref object context)
    {
      serializer.AddTypeIDField(doc, parent, this, context);

      var skipNull = (serializer.Flags ^ BSONSerializationFlags.KeepNull) == 0;

      doc.Add(serializer.PKFieldName, m_Guid, required: true)
        .Add(BSON_FLD_RELATED_TO, m_RelatedTo, skipNull)
        .Add(BSON_FLD_TYPE, m_Type.ToString(), skipNull, required: true)
        .Add(BSON_FLD_SOURCE, m_Source, skipNull)
        .Add(BSON_FLD_TIMESTAMP, m_TimeStamp.ToUniversalTime(), skipNull)
        .Add(BSON_FLD_HOST, m_Host, skipNull)
        .Add(BSON_FLD_FROM, m_From, skipNull)
        .Add(BSON_FLD_TOPIC, m_Topic, skipNull)
        .Add(BSON_FLD_TEXT, m_Text, skipNull)
        .Add(BSON_FLD_PARAMETERS, m_Parameters, skipNull)
        .Add(BSON_FLD_ARCHIVE_DIMENSIONS, m_ArchiveDimensions, skipNull)
        .Add(BSON_FLD_CHANNEL, m_Channel, skipNull);

      if (m_Exception == null) return;

      var we = m_Exception as WrappedException;
      if (we == null)
        we = WrappedException.ForException(m_Exception);

      doc.Add(BSON_FLD_EXCEPTION, serializer.Serialize(we, parent: this), skipNull);
    }

    public void DeserializeFromBSON(BSONSerializer serializer, BSONDocument doc, ref object context)
    {
      m_Guid = doc.TryGetObjectValueOf(serializer.PKFieldName).AsGUID(Guid.Empty);

      m_RelatedTo = doc.TryGetObjectValueOf(BSON_FLD_RELATED_TO).AsGUID(Guid.Empty);

      m_Type = doc.TryGetObjectValueOf(BSON_FLD_TYPE).AsEnum(MessageType.Info);
      m_Source = doc.TryGetObjectValueOf(BSON_FLD_SOURCE).AsInt();
      m_TimeStamp = doc.TryGetObjectValueOf(BSON_FLD_TIMESTAMP).AsDateTime(App.TimeSource.UTCNow);
      m_Host = doc.TryGetObjectValueOf(BSON_FLD_HOST).AsString();
      m_From = doc.TryGetObjectValueOf(BSON_FLD_FROM).AsString();
      m_Topic = doc.TryGetObjectValueOf(BSON_FLD_TOPIC).AsString();
      m_Text = doc.TryGetObjectValueOf(BSON_FLD_TEXT).AsString();
      m_Parameters = doc.TryGetObjectValueOf(BSON_FLD_PARAMETERS).AsString();
      m_ArchiveDimensions = doc.TryGetObjectValueOf(BSON_FLD_ARCHIVE_DIMENSIONS).AsString();
      m_Channel = doc.TryGetObjectValueOf(BSON_FLD_CHANNEL).AsString();

      var ee = doc[BSON_FLD_EXCEPTION] as BSONDocumentElement;
      if (ee == null) return;

      m_Exception = WrappedException.MakeFromBSON(serializer, ee.Value);
    }
    #endregion
  }

  public static class MessageExtensions
  {
    public static Message ThisOrNewSafeWrappedException(this Message msg, bool captureStack = true)
    {
      if (msg == null || msg.Exception == null || msg.Exception is WrappedException) return msg;

      var clone = msg.Clone();
      clone.Exception = WrappedException.ForException(msg.Exception, captureStack);
      return clone;
    }
  }

  internal class MessageList : List<Message>
  {
    public MessageList() { }
    public MessageList(IEnumerable<Message> other) : base(other) { }
  }
}
