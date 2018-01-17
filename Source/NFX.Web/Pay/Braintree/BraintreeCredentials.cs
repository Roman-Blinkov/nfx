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
using System.Text;

using NFX.Security;

namespace NFX.Web.Pay.Braintree
{
  public class BraintreeCredentials : Credentials
  {
    private const string BASIC_AUTH = "Basic {0}";
    private const string BASIC_AUTH_FORMAT = "{0}:{1}";

    public BraintreeCredentials(string merchantId, string publicKey, string privateKey)
    {
      MerchantID = merchantId;
      PublicKey = publicKey;
      PrivateKey = privateKey;
    }

    public readonly string MerchantID;
    public readonly string PublicKey;
    public readonly string PrivateKey;

    public override string ToString() { return "[{0} {1}]".Args(MerchantID, PublicKey); }

    public string AuthorizationHeader
    { get { return BASIC_AUTH.Args(Convert.ToBase64String(Encoding.UTF8.GetBytes(BASIC_AUTH_FORMAT.Args(PublicKey, PrivateKey)))); } }
  }
}
