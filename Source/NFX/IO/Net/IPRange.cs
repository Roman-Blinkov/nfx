///*<FILE_LICENSE>
//* NFX (.NET Framework Extension) Unistack Library
//* Copyright 2003-2017 ITAdapter Corp. Inc.
//*
//* Licensed under the Apache License, Version 2.0 (the "License");
//* you may not use this file except in compliance with the License.
//* You may obtain a copy of the License at
//*
//* http://www.apache.org/licenses/LICENSE-2.0
//*
//* Unless required by applicable law or agreed to in writing, software
//* distributed under the License is distributed on an "AS IS" BASIS,
//* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//* See the License for the specific language governing permissions and
//* limitations under the License.
//</FILE_LICENSE>*/
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace NFX.IO.Net
//{
//  /// <summary>
//  /// Provides a reference-free key for matching of IP/net ranges
//  /// </summary>
//  public struct IPRange : IEqualityComparer<IPRange>
//  {
//    public IPRange(string cidr) //ip/len i.e.:   2.56.34.11/24
//    {

//    }

//    public IPRange(IPAddress ip, int len)// parsed already
//    {
//      if (ip.AddressFamily==System.Net.Sockets.AddressFamily.InterNetworkV6)
//      {

//      }
//      else
//      {//V4
//  //      m_V4 = ip.Address;
//      }


//    }

//    public IPRange(IPAddress ip) // for math making, al bytes are used
//    {

//    }

//  //  private long m_V4;
//  //  private long m_V6H;
//  //  private long m_V6L;




//    public bool Equals(IPRange x, IPRange y)
//    {
//      throw new NotImplementedException();
//    }

//    public int GetHashCode(IPRange obj)
//    {
//      throw new NotImplementedException();
//    }
//  }


//}
