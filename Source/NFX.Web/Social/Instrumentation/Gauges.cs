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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NFX.Instrumentation;
using NFX.Serialization.BSON;

namespace NFX.Web.Social.Instrumentation
{
  [Serializable]
  public abstract class SocialInstrumentationLongGauge : LongGauge, ISocialLogic, IWebInstrument
  {
    protected SocialInstrumentationLongGauge(string source, long value) : base(source, value) { }
  }

  [Serializable]
  [BSONSerializable("5B2BAFD8-1BE9-4B9D-B6D7-0341BD943C8E")]
  public class LoginCount : SocialInstrumentationLongGauge
  {
    protected LoginCount(string source, long value) : base(source, value) { }

    public static void Record(string source, long value)
    {
      var instr = App.Instrumentation;
      if (instr.Enabled)
        instr.Record(new LoginCount(source, value));
    }

    public override string Description { get { return "Login count"; } }
    public override string ValueUnitName { get { return NFX.CoreConsts.UNIT_NAME_TIME; } }

    protected override Datum MakeAggregateInstance() { return new LoginCount(this.Source, 0); }
  }

  [Serializable]
  [BSONSerializable("19F3D531-37B5-492D-B8E4-935CBF89375E")]
  public class LoginErrorCount : SocialInstrumentationLongGauge
  {
    protected LoginErrorCount(string source, long value) : base(source, value) { }

    public static void Record(string source, long value)
    {
      var instr = App.Instrumentation;
      if (instr.Enabled)
        instr.Record(new LoginErrorCount(source, value));
    }

    protected override Datum MakeAggregateInstance() { return new LoginErrorCount(this.Source, 0); }
  }

  [Serializable]
  [BSONSerializable("4CB45FD3-8240-4983-8274-309386611B4C")]
  public class RenewLongTermTokenCount : SocialInstrumentationLongGauge
  {
    protected RenewLongTermTokenCount(string source, long value) : base(source, value) { }

    public override string Description { get { return "Renew long term token"; } }
    public override string ValueUnitName { get { return NFX.CoreConsts.UNIT_NAME_TIME; } }

    public static void Record(string source, long value)
    {
      var instr = App.Instrumentation;
      if (instr.Enabled)
        instr.Record(new RenewLongTermTokenCount(source, value));
    }

    protected override Datum MakeAggregateInstance() { return new RenewLongTermTokenCount(this.Source, 0); }
  }

  [Serializable]
  [BSONSerializable("C28FA3A5-4D27-4EAC-98F0-B4D19954C592")]
  public class PostMsgCount : SocialInstrumentationLongGauge
  {
    protected PostMsgCount(string source, long value) : base(source, value) { }

    public static void Record(string source, long value)
    {
      var instr = App.Instrumentation;
      if (instr.Enabled)
        instr.Record(new PostMsgCount(source, value));
    }


    public override string Description { get { return "Social message post count"; } }
    public override string ValueUnitName { get { return NFX.CoreConsts.UNIT_NAME_MESSAGE; } }

    protected override Datum MakeAggregateInstance() { return new PostMsgCount(this.Source, 0); }
  }

}
