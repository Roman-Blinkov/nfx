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
using System.Data;

namespace NFX.DataAccess.CRUD
{
  public sealed class NotImplementedCRUDDataStore : ICRUDDataStoreImplementation
  {

    public NotImplementedCRUDDataStore()
    {

    }


    public CRUDQueryHandler MakeScriptQueryHandler(QuerySource querySource)
    {
      throw new NotImplementedException();
    }

    public string ScriptFileSuffix
    {
      get { throw new NotImplementedException(); }
    }

    public CRUDDataStoreType StoreType
    {
      get { throw new NotImplementedException(); }
    }

    public ICRUDQueryResolver QueryResolver
    {
      get { throw new NotImplementedException(); }
    }

    public bool SupportsTrueAsynchrony
    {
      get { throw new NotImplementedException(); }
    }

    public Schema GetSchema(Query query)
    {
      throw new NotImplementedException();
    }

    public Task<Schema> GetSchemaAsync(Query query)
    {
      throw new NotImplementedException();
    }

    public List<RowsetBase> Load(params Query[] queries)
    {
      throw new NotImplementedException();
    }

    public Task<List<RowsetBase>> LoadAsync(params Query[] queries)
    {
      throw new NotImplementedException();
    }

    public RowsetBase LoadOneRowset(Query query)
    {
      throw new NotImplementedException();
    }

    public Task<RowsetBase> LoadOneRowsetAsync(Query query)
    {
      throw new NotImplementedException();
    }

    public Row LoadOneRow(Query query)
    {
      throw new NotImplementedException();
    }

    public Task<Row> LoadOneRowAsync(Query query)
    {
      throw new NotImplementedException();
    }

    public Cursor OpenCursor(Query query)
    {
      throw new NotImplementedException();
    }

    public Task<Cursor> OpenCursorAsync(Query query)
    {
      throw new NotImplementedException();
    }

    public int Save(params RowsetBase[] rowsets)
    {
      throw new NotImplementedException();
    }

    public Task<int> SaveAsync(params RowsetBase[] rowsets)
    {
      throw new NotImplementedException();
    }

    public int ExecuteWithoutFetch(params Query[] queries)
    {
      throw new NotImplementedException();
    }

    public Task<int> ExecuteWithoutFetchAsync(params Query[] queries)
    {
      throw new NotImplementedException();
    }

    public int Insert(Row row, FieldFilterFunc filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<int> InsertAsync(Row row, FieldFilterFunc filter = null)
    {
      throw new NotImplementedException();
    }

    public int Upsert(Row row, FieldFilterFunc filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<int> UpsertAsync(Row row, FieldFilterFunc filter = null)
    {
      throw new NotImplementedException();
    }

    public int Update(Row row, IDataStoreKey key = null, FieldFilterFunc filter = null)
    {
      throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(Row row, IDataStoreKey key = null, FieldFilterFunc filter = null)
    {
      throw new NotImplementedException();
    }

    public int Delete(Row row, IDataStoreKey key = null)
    {
      throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Row row, IDataStoreKey key = null)
    {
      throw new NotImplementedException();
    }

    public bool SupportsTransactions
    {
      get { throw new NotImplementedException(); }
    }

    public CRUDTransaction BeginTransaction(System.Data.IsolationLevel iso = IsolationLevel.ReadCommitted, TransactionDisposeBehavior behavior = TransactionDisposeBehavior.CommitOnDispose)
    {
      throw new NotImplementedException();
    }

    public Task<CRUDTransaction> BeginTransactionAsync(System.Data.IsolationLevel iso = IsolationLevel.ReadCommitted, TransactionDisposeBehavior behavior = TransactionDisposeBehavior.CommitOnDispose)
    {
      throw new NotImplementedException();
    }

    public StoreLogLevel LogLevel
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public string TargetName
    {
      get { throw new NotImplementedException(); }
    }

    public void TestConnection()
    {
      throw new NotImplementedException();
    }

    public ulong ComponentSID
    {
      get { throw new NotImplementedException(); }
    }

    public object ComponentDirector
    {
      get { throw new NotImplementedException(); }
    }

    public string ComponentCommonName
    {
      get { throw new NotImplementedException(); }
    }

    public void Dispose()
    {
    }

    public void Configure(Environment.IConfigSectionNode node)
    {
    }

    public bool InstrumentationEnabled
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public IEnumerable<KeyValuePair<string, Type>> ExternalParameters
    {
      get { throw new NotImplementedException(); }
    }

    public IEnumerable<KeyValuePair<string, Type>> ExternalParametersForGroups(params string[] groups)
    {
      throw new NotImplementedException();
    }

    public bool ExternalGetParameter(string name, out object value, params string[] groups)
    {
      throw new NotImplementedException();
    }

    public bool ExternalSetParameter(string name, object value, params string[] groups)
    {
      throw new NotImplementedException();
    }
  }
}
