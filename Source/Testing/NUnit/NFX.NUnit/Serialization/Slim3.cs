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
using System.Threading.Tasks;
using System.IO;

using NUnit.Framework;

using NFX;
using NFX.Collections;
using NFX.Serialization.Slim;
using NFX.Serialization.JSON;

namespace NFX.NUnit.Serialization
{
  [TestFixture]
  public class Slim3
  {

    [Test]
    public void NLS_Root()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var dIn = new NLSMap("eng{n='name' d='description'} rus{n='имя' d='описание'}".AsLaconicConfig());

        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (NLSMap)s.Deserialize(ms);

        Assert.AreEqual( 2, dOut.Count);
        Assert.AreEqual( "name", dOut.Get(NLSMap.GetParts.Name, "eng"));
        Assert.AreEqual( "имя", dOut.Get(NLSMap.GetParts.Name, "rus"));

        Assert.AreEqual( "description", dOut.Get(NLSMap.GetParts.Description, "eng"));
        Assert.AreEqual( "описание", dOut.Get(NLSMap.GetParts.Description, "rus"));
      }
    }

        internal class nlsCls
        {
          public NLSMap Map;
        }

    [Test]
    public void NLS_InClass()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var dIn = new nlsCls{ Map = new NLSMap("eng{n='name' d='description'} rus{n='имя' d='описание'}".AsLaconicConfig())};

        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (nlsCls)s.Deserialize(ms);

        Assert.IsNotNull(dOut);

        Assert.AreEqual( 2, dOut.Map.Count);
        Assert.AreEqual( "name", dOut.Map.Get(NLSMap.GetParts.Name, "eng"));
        Assert.AreEqual( "имя", dOut.Map.Get(NLSMap.GetParts.Name, "rus"));

        Assert.AreEqual( "description", dOut.Map.Get(NLSMap.GetParts.Description, "eng"));
        Assert.AreEqual( "описание", dOut.Map.Get(NLSMap.GetParts.Description, "rus"));
      }
    }


        internal struct nlsStruct
        {
          public NLSMap Map;
        }

    [Test]
    public void NLS_InStruct()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var dIn = new nlsStruct{ Map = new NLSMap("eng{n='name' d='description'} rus{n='имя' d='описание'}".AsLaconicConfig())};

        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (nlsStruct)s.Deserialize(ms);

        Assert.AreEqual( 2, dOut.Map.Count);
        Assert.AreEqual( "name", dOut.Map.Get(NLSMap.GetParts.Name, "eng"));
        Assert.AreEqual( "имя", dOut.Map.Get(NLSMap.GetParts.Name, "rus"));

        Assert.AreEqual( "description", dOut.Map.Get(NLSMap.GetParts.Description, "eng"));
        Assert.AreEqual( "описание", dOut.Map.Get(NLSMap.GetParts.Description, "rus"));
      }
    }


    [Test]
    public void NLS_Array()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var dIn = new NLSMap[]{
                        new NLSMap("eng{n='name' d='description'} rus{n='имя' d='описание'}".AsLaconicConfig()),
                        new NLSMap("eng{n='color' d='of product'} rus{n='zvet' d='producta'}".AsLaconicConfig()),
                        new NLSMap("eng{n='size' d='of item'} rus{n='razmer' d='tovara'}".AsLaconicConfig())
                      };


        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (NLSMap[])s.Deserialize(ms);

        Assert.IsNotNull(dOut);

        Assert.AreEqual( 3, dOut.Length);

        Assert.AreEqual( "name",        dOut[0].Get(NLSMap.GetParts.Name, "eng"));
        Assert.AreEqual( "имя",         dOut[0].Get(NLSMap.GetParts.Name, "rus"));
        Assert.AreEqual( "description", dOut[0].Get(NLSMap.GetParts.Description, "eng"));
        Assert.AreEqual( "описание",    dOut[0].Get(NLSMap.GetParts.Description, "rus"));

        Assert.AreEqual( "color",      dOut[1].Get(NLSMap.GetParts.Name, "eng"));
        Assert.AreEqual( "zvet",       dOut[1].Get(NLSMap.GetParts.Name, "rus"));
        Assert.AreEqual( "of product", dOut[1].Get(NLSMap.GetParts.Description, "eng"));
        Assert.AreEqual( "producta",   dOut[1].Get(NLSMap.GetParts.Description, "rus"));

        Assert.AreEqual( "size",    dOut[2].Get(NLSMap.GetParts.Name, "eng"));
        Assert.AreEqual( "razmer",  dOut[2].Get(NLSMap.GetParts.Name, "rus"));
        Assert.AreEqual( "of item", dOut[2].Get(NLSMap.GetParts.Description, "eng"));
        Assert.AreEqual( "tovara",  dOut[2].Get(NLSMap.GetParts.Description, "rus"));
      }
    }



    [Test]
    public void StringMap_Sensitive()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var dIn = new StringMap
        {
          {"a", "Alex"},
          {"b", "Boris"}
        };

        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (StringMap)s.Deserialize(ms);

        Assert.IsNotNull(dOut);

        Assert.IsTrue( dOut.CaseSensitive );
        Assert.AreEqual( 2, dOut.Count);
        Assert.AreEqual( "Alex", dOut["a"]);
        Assert.AreEqual( null, dOut["A"]);

        Assert.AreEqual( "Boris", dOut["b"]);
        Assert.AreEqual( null, dOut["B"]);
      }
    }

    [Test]
    public void StringMap_Insensitive()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var dIn = new StringMap(false)
        {
          {"a", "Alex"},
          {"b", "Boris"}
        };

        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (StringMap)s.Deserialize(ms);

        Assert.IsNotNull(dOut);

        Assert.IsFalse( dOut.CaseSensitive );
        Assert.AreEqual( 2, dOut.Count);
        Assert.AreEqual( "Alex", dOut["a"]);
        Assert.AreEqual( "Alex", dOut["A"]);

        Assert.AreEqual( "Boris", dOut["b"]);
        Assert.AreEqual( "Boris", dOut["B"]);
      }
    }


        internal class stringMapCls
        {
          public StringMap Map1;
          public StringMap Map2;
        }


    [Test]
    public void StringMap_One_InClass()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var dIn = new stringMapCls
        {
          Map1 = new StringMap(false)
          {
            {"a", "Alex"},
            {"b", "Boris"}
          }
        };

        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (stringMapCls)s.Deserialize(ms);

        Assert.IsNotNull(dOut);
        Assert.IsNotNull(dOut.Map1);
        Assert.IsNull(dOut.Map2);

        Assert.IsFalse( dOut.Map1.CaseSensitive );
        Assert.AreEqual( 2, dOut.Map1.Count);
        Assert.AreEqual( "Alex", dOut.Map1["a"]);
        Assert.AreEqual( "Alex", dOut.Map1["A"]);

        Assert.AreEqual( "Boris", dOut.Map1["b"]);
        Assert.AreEqual( "Boris", dOut.Map1["B"]);
      }
    }


    [Test]
    public void StringMap_TwoRefOne_InClass()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var dIn = new stringMapCls
        {
          Map1 = new StringMap(false)
          {
            {"a", "Alex"},
            {"b", "Boris"}
          }
        };
        dIn.Map2 = dIn.Map1; //SAME REF!

        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (stringMapCls)s.Deserialize(ms);

        Assert.IsNotNull(dOut);
        Assert.IsNotNull(dOut.Map1);
        Assert.IsNotNull(dOut.Map2);

        Assert.IsTrue( object.ReferenceEquals( dOut.Map1, dOut.Map2 ));//IMPORTANT!

        Assert.IsFalse( dOut.Map1.CaseSensitive );
        Assert.AreEqual( 2, dOut.Map1.Count);
        Assert.AreEqual( "Alex", dOut.Map1["a"]);
        Assert.AreEqual( "Alex", dOut.Map1["A"]);

        Assert.AreEqual( "Boris", dOut.Map1["b"]);
        Assert.AreEqual( "Boris", dOut.Map1["B"]);
      }
    }


    [TestCase(10)]
    [TestCase(210)]
    [TestCase(3240)]
    [TestCase(128000)]
    [TestCase(512000)]
    [TestCase(1512000)]
    public void StringMap_WideCharsLong(int cnt)
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var original1 = new string('久', cnt);
        var original2 = "就是巴尼宝贝儿吧，俺说。有什么怪事儿或是好事儿吗？ когда американские авианосцы 'Уинсон' и 'Мидуэй' приблизились 지구상의　３대 we have solved the problem";

        var dIn = new stringMapCls
        {
          Map1 = new StringMap(false)
          {
            {"a", original1},
            {"b", original2}
          }
        };

        s.Serialize(ms, dIn);
        ms.Seek(0, SeekOrigin.Begin);

        var dOut = (stringMapCls)s.Deserialize(ms);

        Assert.IsNotNull(dOut);
        Assert.IsNotNull(dOut.Map1);
        Assert.IsNull(dOut.Map2);

        Assert.IsFalse( dOut.Map1.CaseSensitive );
        Assert.AreEqual( 2, dOut.Map1.Count);


        Assert.AreEqual( original1, dOut.Map1["a"]);
        Assert.AreEqual( original1, dOut.Map1["A"]);

        Assert.AreEqual( original2, dOut.Map1["b"]);
        Assert.AreEqual( original2, dOut.Map1["B"]);
      }
    }

    [Test]
    public void StringManyLanguages()
    {
      using (var ms = new MemoryStream())
      {
        var s = new SlimSerializer();

        var original =@"
        外国語の学習と教授

Language Learning and Teaching

Изучение и обучение иностранных языков

Tere Daaheng Aneng Karimah

語文教學・语文教学

Enseñanza y estudio de idiomas

Изучаване и Преподаване на Чужди Езици

ქართული ენის შესწავლა და სწავლება

'læŋɡwidʒ 'lɘr:niŋ ænd 'ti:tʃiŋ

Lus kawm thaib qhia

Ngôn Ngữ, Sự học,

‭‫ללמוד וללמד את השֵפה

L'enseignement et l'étude des langues

말배우기와 가르치기

Nauka języków obcych

Γλωσσική Εκμὰθηση και Διδασκαλία

‭‫ﺗﺪﺭﯾﺲ ﻭ ﯾﺎﺩﮔﯿﺮﯼ ﺯﺑﺎﻥ

Sprachlernen und -lehren

‭‫ﺗﻌﻠﻢ ﻭﺗﺪﺭﻳﺲ ﺍﻟﻌﺮﺑﻴﺔ

เรียนและสอนภาษา";


        s.Serialize(ms, original);
        ms.Seek(0, SeekOrigin.Begin);

        var got = s.Deserialize(ms) as string;

        Assert.IsNotNull(got);
        Assert.AreEqual( original, got);
      }
    }




  }
}
