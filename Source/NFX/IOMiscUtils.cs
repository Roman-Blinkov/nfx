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
using System.IO;
using System.Security.AccessControl;
using System.Net;
using System.Text;
using System.Security.Principal;

namespace NFX
{
    /// <summary>
    /// Misc utils for I/O
    /// </summary>
    public static class IOMiscUtils
    {
        public const int IO_WAIT_GRANULARITY_MS = 200;
        public const int IO_WAIT_MIN_TIMEOUT = 100;
        public const int IO_WAIT_DEFAULT_TIMEOUT = 2000;



        /// <summary>
        /// Reads first line from the string
        /// </summary>
        public static string ReadLine(this string str)
        {
            StringBuilder buf = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
                if ((str[i] == '\n') || (str[i] == '\r'))
                    break;
                else
                    buf.Append(str[i]);

            return buf.ToString();
        }

        /// <summary>
        /// Fetch the content of a given URL.
        /// </summary>
        /// <returns>
        /// Return fetched URL as a string, or null string when resulting status code is not HttpStatusCode.OK.
        /// </returns>
        public static KeyValuePair<HttpStatusCode,string> GetURL(string urlAddress, int timeout = 5000)
        {
            var req     = (HttpWebRequest)WebRequest.Create(urlAddress);
            req.Timeout = timeout;
            var res     = (HttpWebResponse)req.GetResponse();
            try
            {
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    var strm = res.GetResponseStream();
                    var rds  = res.CharacterSet == null
                             ? new StreamReader(strm)
                             : new StreamReader(strm, Encoding.GetEncoding(res.CharacterSet));
                    var s = rds.ReadToEnd();
                    rds.Close();
                    return new KeyValuePair<HttpStatusCode, string>(res.StatusCode, s);
                }
            }
            finally
            {
                res.Close();
            }
            return new KeyValuePair<HttpStatusCode, string>(res.StatusCode, null);
        }

        [ThreadStatic] private static byte[] ts_CopyBuffer;
        /// <summary>
        /// Copies one stream into another using temp buffer
        /// </summary>
        public static void CopyStream(Stream from, Stream to, bool noCache = false)
        {
            if (ts_CopyBuffer==null) ts_CopyBuffer = new byte[98*1024];
            int read;
            while((read = from.Read(ts_CopyBuffer, 0, ts_CopyBuffer.Length)) > 0)
                to.Write(ts_CopyBuffer, 0, read);

            if (noCache)
              ts_CopyBuffer = null;
        }


        /// <summary>
        /// Reads an integer encoded as big endian from buffer at index 0
        /// </summary>
        public static int ReadBEInt32(this byte[] buf)
        {
            int n = 0;
            return ReadBEInt32(buf, ref n);
        }

        /// <summary>
        /// Reads an integer encoded as little endian from buffer at index 0
        /// </summary>
        public static int ReadLEInt32(this byte[] buf)
        {
            int n = 0;
            return ReadLEInt32(buf, ref n);
        }

        /// <summary>
        /// Reads an unsigned integer encoded as big endian from buffer at index 0
        /// </summary>
        public static uint ReadBEUInt32(this byte[] buf)
        {
            int n = 0;
            return ReadBEUInt32(buf, ref n);
        }

        /// <summary>
        /// Reads an unsigned integer encoded as little endian from buffer at index 0
        /// </summary>
        public static uint ReadLEUInt32(this byte[] buf)
        {
            int n = 0;
            return ReadLEUInt32(buf, ref n);
        }

        /// <summary>
        /// Reads an integer encoded as big endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static int ReadBEInt32(this byte[] buf, ref long idx)
        {
            int n = (int)idx;
            int result = ReadBEInt32(buf, ref n);
            idx = n;
            return result;
        }

        /// <summary>
        /// Reads an integer encoded as little endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static int ReadLEInt32(this byte[] buf, ref long idx)
        {
            int n = (int)idx;
            int result = ReadLEInt32(buf, ref n);
            idx = n;
            return result;
        }

        /// <summary>
        /// Reads an integer encoded as big endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static int ReadBEInt32(this byte[] buf, ref int idx)
        {
            return  ((int)buf[idx++] << 24) +
                    ((int)buf[idx++] << 16) +
                    ((int)buf[idx++] << 8) +
                     (int)buf[idx++];
        }

        /// <summary>
        /// Reads an integer encoded as little endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static int ReadLEInt32(this byte[] buf, ref int idx)
        {
            return   (int)buf[idx++] +
                    ((int)buf[idx++] << 8) +
                    ((int)buf[idx++] << 16) +
                    ((int)buf[idx++] << 24);
        }

        /// <summary>
        /// Reads an unsigned integer encoded as big endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static uint ReadBEUInt32(this byte[] buf, ref int idx)
        {
            return  ((uint)buf[idx++] << 24) +
                    ((uint)buf[idx++] << 16) +
                    ((uint)buf[idx++] << 8) +
                     (uint)buf[idx++];
        }

        /// <summary>
        /// Reads an unsigned integer encoded as little endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static uint ReadLEUInt32(this byte[] buf, ref int idx)
        {
            return   (uint)buf[idx++] +
                    ((uint)buf[idx++] << 8) +
                    ((uint)buf[idx++] << 16) +
                    ((uint)buf[idx++] << 24);
        }

        /// <summary>
        /// Reads an unsigned integer encoded as big endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static uint ReadBEUInt32(this byte[] buf, ref long idx)
        {
            return  ((uint)buf[idx++] << 24) +
                    ((uint)buf[idx++] << 16) +
                    ((uint)buf[idx++] << 8) +
                     (uint)buf[idx++];
        }

        /// <summary>
        /// Reads an unsigned integer encoded as little endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static uint ReadLEUInt32(this byte[] buf, ref long idx)
        {
            return   (uint)buf[idx++] +
                    ((uint)buf[idx++] << 8) +
                    ((uint)buf[idx++] << 16) +
                    ((uint)buf[idx++] << 24);
        }

        /// <summary>
        /// Reads an integer encoded as big endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static UInt64 ReadBEUInt64(this byte[] buf, ref int idx)
        {
            return ((ulong)buf[idx++] << 56) +
                   ((ulong)buf[idx++] << 48) +
                   ((ulong)buf[idx++] << 40) +
                   ((ulong)buf[idx++] << 32) +
                   ((ulong)buf[idx++] << 24) +
                   ((ulong)buf[idx++] << 16) +
                   ((ulong)buf[idx++] << 8 ) +
                   ((ulong)buf[idx++]      );
        }

        /// <summary>
        /// Reads an integer encoded as little endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static UInt64 ReadLEUInt64(this byte[] buf, ref int idx)
        {
            return ((ulong)buf[idx++]      ) +
                   ((ulong)buf[idx++] << 8 ) +
                   ((ulong)buf[idx++] << 16) +
                   ((ulong)buf[idx++] << 24) +
                   ((ulong)buf[idx++] << 32) +
                   ((ulong)buf[idx++] << 40) +
                   ((ulong)buf[idx++] << 48) +
                   ((ulong)buf[idx++] << 56);
        }

        /// <summary>
        /// Reads an integer encoded as big endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static UInt64 ReadBEUInt64(this byte[] buf, int idx = 0)
        {
            return ((ulong)buf[idx++] << 56) +
                   ((ulong)buf[idx++] << 48) +
                   ((ulong)buf[idx++] << 40) +
                   ((ulong)buf[idx++] << 32) +
                   ((ulong)buf[idx++] << 24) +
                   ((ulong)buf[idx++] << 16) +
                   ((ulong)buf[idx++] << 8 ) +
                   ((ulong)buf[idx++]      );
        }

        /// <summary>
        /// Reads an integer encoded as little endian from buffer at the specified index
        /// and increments the idx by the number of bytes read
        /// </summary>
        public static UInt64 ReadLEUInt64(this byte[] buf, int idx = 0)
        {
            return ((ulong)buf[idx++]      ) +
                   ((ulong)buf[idx++] << 8 ) +
                   ((ulong)buf[idx++] << 16) +
                   ((ulong)buf[idx++] << 24) +
                   ((ulong)buf[idx++] << 32) +
                   ((ulong)buf[idx++] << 40) +
                   ((ulong)buf[idx++] << 48) +
                   ((ulong)buf[idx++] << 56);
        }

        /// <summary>
        /// Reads a short encoded as big endian from buffer at the specified index
        /// </summary>
        public static short ReadBEShort(this byte[] buf, ref int idx)
        {
            return (short)(
                         (((int)buf[idx++] << 8 ) & 0xff00) +
                         (((int)buf[idx++]      ) & 0xff)
                        );
        }

        /// <summary>
        /// Reads a short encoded as little endian from buffer at the specified index
        /// </summary>
        public static short ReadLEShort(this byte[] buf, ref int idx)
        {
            return (short)(
                         (((int)buf[idx++]      ) & 0xff) +
                         (((int)buf[idx++] << 8 ) & 0xff00)
                        );
        }


        /// <summary>
        /// Reads a short encoded as big endian from stream
        /// </summary>
        public static short ReadBEShort(this Stream s)
        {
            var b1 = s.ReadByte();
            if (b1<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEShort()");

            var b2 = s.ReadByte();
            if (b2<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEShort()");

            return (short)(
                         (b1 << 8 ) +
                         (b2)
                        );
        }

        /// <summary>
        /// Reads a short encoded as little endian from stream
        /// </summary>
        public static short ReadLEShort(this Stream s)
        {
            var b1 = s.ReadByte();
            if (b1<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEShort()");

            var b2 = s.ReadByte();
            if (b2<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEShort()");

            return (short)((b2 << 8) + b1);
        }

        /// <summary>
        /// Reads an ushort encoded as big endian from stream
        /// </summary>
        public static ushort ReadBEUShort(this Stream s)
        {
            var b1 = s.ReadByte();
            if (b1<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUShort()");

            var b2 = s.ReadByte();
            if (b2<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUShort()");

            return (ushort)(
                         (b1 << 8 ) +
                         (b2)
                        );
        }

        /// <summary>
        /// Reads an ushort encoded as little endian from stream
        /// </summary>
        public static ushort ReadLEUShort(this Stream s)
        {
            var b1 = s.ReadByte();
            if (b1<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUShort()");

            var b2 = s.ReadByte();
            if (b2<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUShort()");

            return (ushort)((b2 << 8) + b1);
        }

        /// <summary>
        /// Reads an integer encoded as big endian from buffer at the specified index
        /// </summary>
        public static Int32 ReadBEInt32(this Stream s)
        {
            var b1 = s.ReadByte();
            if (b1<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEInt32()");

            var b2 = s.ReadByte();
            if (b2<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEInt32()");

            var b3 = s.ReadByte();
            if (b3<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEInt32()");

            var b4 = s.ReadByte();
            if (b4<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEInt32()");

            return (b1 << 24) +
                   (b2 << 16) +
                   (b3 << 8 ) +
                   (b4 );
        }

        /// <summary>
        /// Reads an integer encoded as little endian from buffer at the specified index
        /// </summary>
        public static int ReadLEInt32(this Stream s)
        {
            var b1 = s.ReadByte();
            if (b1<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEInt32()");

            var b2 = s.ReadByte();
            if (b2<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEInt32()");

            var b3 = s.ReadByte();
            if (b3<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEInt32()");

            var b4 = s.ReadByte();
            if (b4<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEInt32()");

            return (b4 << 24) +
                   (b3 << 16) +
                   (b2 <<  8) +
                   (b1);
        }

        /// <summary>
        /// Reads an integer encoded as big endian from buffer at the specified index
        /// </summary>
        public static ulong ReadBEUInt64(this Stream s)
        {
           var b1 = s.ReadByte();
           if (b1<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUInt64()");

           var b2 = s.ReadByte();
           if (b2<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUInt64()");

           var b3 = s.ReadByte();
           if (b3<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUInt64()");

           var b4 = s.ReadByte();
           if (b4<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUInt64()");

           var b5 = s.ReadByte();
           if (b5<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUInt64()");

           var b6 = s.ReadByte();
           if (b6<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUInt64()");

           var b7 = s.ReadByte();
           if (b7<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUInt64()");

           var b8 = s.ReadByte();
           if (b8<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadBEUInt64()");



          return ((UInt64)b1 << 56) +
                 ((UInt64)b2 << 48) +
                 ((UInt64)b3 << 40) +
                 ((UInt64)b4 << 32) +
                 ((UInt64)b5 << 24) +
                 ((UInt64)b6 << 16) +
                 ((UInt64)b7 << 8)  +
                 ((UInt64)b8) ;
        }

        /// <summary>
        /// Reads an integer encoded as little endian from buffer at the specified index
        /// </summary>
        public static ulong ReadLEUInt64(this Stream s)
        {
           var b1 = s.ReadByte();
           if (b1<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUInt64()");

           var b2 = s.ReadByte();
           if (b2<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUInt64()");

           var b3 = s.ReadByte();
           if (b3<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUInt64()");

           var b4 = s.ReadByte();
           if (b4<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUInt64()");

           var b5 = s.ReadByte();
           if (b5<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUInt64()");

           var b6 = s.ReadByte();
           if (b6<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUInt64()");

           var b7 = s.ReadByte();
           if (b7<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUInt64()");

           var b8 = s.ReadByte();
           if (b8<0) throw new IO.NFXIOException(StringConsts.STREAM_READ_EOF_ERROR+"ReadLEUInt64()");

          return ((ulong)b8 << 56) +
                 ((ulong)b7 << 48) +
                 ((ulong)b6 << 40) +
                 ((ulong)b5 << 32) +
                 ((ulong)b4 << 24) +
                 ((ulong)b3 << 16) +
                 ((ulong)b2 << 8)  +
                 ((ulong)b1) ;
        }


        /// <summary>
        /// Writes an integer encoded as big endian to buffer at index 0
        /// </summary>
        public static void WriteBEInt32(this byte[] buf, Int32 value)
        {
           WriteBEInt32(buf, 0, value);
        }

        /// <summary>
        /// Writes an integer encoded as little endian to buffer at index 0
        /// </summary>
        public static void WriteLEInt32(this byte[] buf, Int32 value)
        {
           WriteLEInt32(buf, 0, value);
        }

        /// <summary>
        /// Writes an integer encoded as big endian to buffer at the specified index
        /// </summary>
        public static void WriteBEInt32(this byte[] buf, int idx, Int32 value)
        {
            buf[idx+0] = (byte)(value  >> 24);
            buf[idx+1] = (byte)(value  >> 16);
            buf[idx+2] = (byte)(value  >> 8);
            buf[idx+3] = (byte)(value );
        }

        /// <summary>
        /// Writes an integer encoded as little endian to buffer at the specified index
        /// </summary>
        public static void WriteLEInt32(this byte[] buf, int idx, Int32 value)
        {
            buf[idx+0] = (byte)(value);
            buf[idx+1] = (byte)(value >> 8);
            buf[idx+2] = (byte)(value >> 16);
            buf[idx+3] = (byte)(value >> 24 );
        }

        /// <summary>
        /// Writes an unsigned integer encoded as big endian to buffer at index 0
        /// </summary>
        public static void WriteBEUInt32(this byte[] buf, UInt32 value)
        {
           WriteBEUInt32(buf, 0, value);
        }

        /// <summary>
        /// Writes an unsigned integer encoded as little endian to buffer at index 0
        /// </summary>
        public static void WriteLEUInt32(this byte[] buf, UInt32 value)
        {
           WriteLEUInt32(buf, 0, value);
        }

        /// <summary>
        /// Writes an unsigned integer encoded as big endian to buffer at the specified index
        /// </summary>
        public static void WriteBEUInt32(this byte[] buf, int idx, UInt32 value)
        {
            buf[idx+0] = (byte)(value  >> 24);
            buf[idx+1] = (byte)(value  >> 16);
            buf[idx+2] = (byte)(value  >> 8);
            buf[idx+3] = (byte)(value );
        }

        /// <summary>
        /// Writes an unsigned integer encoded as little endian to buffer at the specified index
        /// </summary>
        public static void WriteLEUInt32(this byte[] buf, int idx, UInt32 value)
        {
            buf[idx+0] = (byte)(value);
            buf[idx+1] = (byte)(value >> 8);
            buf[idx+2] = (byte)(value >> 16);
            buf[idx+3] = (byte)(value >> 24);
        }

        /// <summary>
        /// Writes an unsigned long integer encoded as big endian to buffer at the beginning
        /// </summary>
        public static void WriteBEUInt64(this byte[] buf, UInt64 value)
        {
          buf.WriteBEUInt64(0, value);
        }

        /// <summary>
        /// Writes an unsigned long integer encoded as little endian to buffer at the beginning
        /// </summary>
        public static void WriteLEUInt64(this byte[] buf, UInt64 value)
        {
          buf.WriteLEUInt64(0, value);
        }

        /// <summary>
        /// Writes an unsigned long integer encoded as big endian to buffer at the specified index
        /// </summary>
        public static void WriteBEUInt64(this byte[] buf, int idx, UInt64 value)
        {
          buf[idx+0] = (byte)(value >> 56);
          buf[idx+1] = (byte)(value >> 48);
          buf[idx+2] = (byte)(value >> 40);
          buf[idx+3] = (byte)(value >> 32);
          buf[idx+4] = (byte)(value >> 24);
          buf[idx+5] = (byte)(value >> 16);
          buf[idx+6] = (byte)(value >> 8);
          buf[idx+7] = (byte)(value);
        }

        /// <summary>
        /// Writes an unsigned long integer encoded as little endian to buffer at the specified index
        /// </summary>
        public static void WriteLEUInt64(this byte[] buf, int idx, UInt64 value)
        {
          buf[idx+0] = (byte)(value);
          buf[idx+1] = (byte)(value >> 8 );
          buf[idx+2] = (byte)(value >> 16);
          buf[idx+3] = (byte)(value >> 24);
          buf[idx+4] = (byte)(value >> 32);
          buf[idx+5] = (byte)(value >> 40);
          buf[idx+6] = (byte)(value >> 48);
          buf[idx+7] = (byte)(value >> 56);
        }

        /// <summary>
        /// Writes a short encoded as big endian to buffer at the specified index
        /// </summary>
        public static void WriteBEShort(this byte[] buf, int idx, short value)
        {
            buf[idx+0] = (byte)(value >> 8);
            buf[idx+1] = (byte)(value );
        }

        /// <summary>
        /// Writes a short encoded as little endian to buffer at the specified index
        /// </summary>
        public static void WriteLEShort(this byte[] buf, int idx, short value)
        {
            buf[idx+0] = (byte)(value);
            buf[idx+1] = (byte)(value >> 8);
        }


        /// <summary>
        /// Writes a short encoded as big endian to the given stream
        /// </summary>
        public static void WriteBEShort(this Stream s, short value)
        {
            s.WriteByte((byte)(value >> 8));
            s.WriteByte((byte)value);
        }

        /// <summary>
        /// Writes a short encoded as little endian to the given stream
        /// </summary>
        public static void WriteLEShort(this Stream s, short value)
        {
            s.WriteByte((byte)value);
            s.WriteByte((byte)(value >> 8));
        }

        /// <summary>
        /// Writes an ushort encoded as big endian to the given stream
        /// </summary>
        public static void WriteBEUShort(this Stream s, ushort value)
        {
            s.WriteByte((byte)(value >> 8));
            s.WriteByte((byte)value);
        }

        /// <summary>
        /// Writes an ushort encoded as little endian to the given stream
        /// </summary>
        public static void WriteLEUShort(this Stream s, ushort value)
        {
            s.WriteByte((byte)value);
            s.WriteByte((byte)(value >> 8));
        }

        /// <summary>
        /// Writes an integer encoded as big endian to the given stream
        /// </summary>
        public static void WriteBEInt32(this Stream s, Int32 value)
        {
            s.WriteByte((byte)(value  >> 24));
            s.WriteByte((byte)(value  >> 16));
            s.WriteByte((byte)(value  >> 8));
            s.WriteByte((byte)(value));
        }

        /// <summary>
        /// Writes an integer encoded as little endian to the given stream
        /// </summary>
        public static void WriteLEInt32(this Stream s, int value)
        {
            s.WriteByte((byte)(value));
            s.WriteByte((byte)(value  >> 8));
            s.WriteByte((byte)(value  >> 16));
            s.WriteByte((byte)(value  >> 24));
        }

        /// <summary>
        /// Writes an unsigned long integer encoded as big endian to the given stream
        /// </summary>
        public static void WriteBEUInt64(this Stream s, UInt64 value)
        {
          s.WriteByte((byte)(value >> 56));
          s.WriteByte((byte)(value >> 48));
          s.WriteByte((byte)(value >> 40));
          s.WriteByte((byte)(value >> 32));
          s.WriteByte((byte)(value >> 24));
          s.WriteByte((byte)(value >> 16));
          s.WriteByte((byte)(value >> 8));
          s.WriteByte((byte)(value));
        }

        /// <summary>
        /// Writes an unsigned long integer encoded as little endian to the given stream
        /// </summary>
        public static void WriteLEUInt64(this Stream s, ulong value)
        {
          s.WriteByte((byte)(value));
          s.WriteByte((byte)(value >> 8));
          s.WriteByte((byte)(value >> 16));
          s.WriteByte((byte)(value >> 24));
          s.WriteByte((byte)(value >> 32));
          s.WriteByte((byte)(value >> 40));
          s.WriteByte((byte)(value >> 48));
          s.WriteByte((byte)(value >> 56));
        }


        public static IEnumerable<char> AsCharEnumerable(this Stream stream)
        {
          using (var reader = new StreamReader(stream))
          {
            char[] chars = new char[4096];
            int length;
            while ((length = reader.Read(chars, 0, chars.Length)) != 0)
              for (int i = 0; i < length; i++)
                yield return chars[i];
          }
        }

        public static IEnumerable<char> AsCharEnumerable(this TextReader reader)
        {
          char[] chars = new char[4096];
          int length;
          while ((length = reader.Read(chars, 0, chars.Length)) != 0)
            for (int i = 0; i < length; i++)
              yield return chars[i];
        }

        /// <summary>
        /// Deleted file if it exists - does not block until file is deleted, the behavior is up to the OS
        /// </summary>
        /// <param name="fileName">Full file name with path</param>
        public static void EnsureFileEventuallyDeleted(string fileName)
        {
          if (File.Exists(fileName))
            File.Delete(fileName);
        }

        /// <summary>
        /// Tries to delete the specified directory if it exists BLOCKING for up to the specified interval until directory is PHYSICALLY deleted.
        /// Returns true when directory either did not exist in the first place or was successfully deleted (with confirmation).
        /// Returns false when directory could not be confirmed to be deleted within the specified timeout, this does not mean
        ///  that the OS will not delete the directory later, so calling this function in a loop is expected.
        ///  NOTE: Directory.Delete() does not guarantee that directory is no longer on disk upon its return
        /// </summary>
        /// <param name="dirName">Directory to delete</param>
        /// <param name="timeoutMs">Timeout in ms</param>
        public static bool EnsureDirectoryDeleted(string dirName, int timeoutMs = IO_WAIT_DEFAULT_TIMEOUT)
        {
          if (dirName.IsNullOrWhiteSpace()) return false;
          if (timeoutMs<IO_WAIT_MIN_TIMEOUT) timeoutMs = IO_WAIT_MIN_TIMEOUT;


          if (!Directory.Exists(dirName)) return true;

          Directory.Delete(dirName, true);//MARKS directory for deletion, but does not delete it

          var sw = System.Diagnostics.Stopwatch.StartNew();
          while(sw.ElapsedMilliseconds < timeoutMs)
          {
             if (!Directory.Exists(dirName)) return true;//actual check for physical presence on disk
             System.Threading.Thread.Sleep(IO_WAIT_GRANULARITY_MS);
          }
          return false;
        }


        /// <summary>
        /// Creates directory and immediately grants it accessibility rules for everyone if it does not exists,
        ///  or returns the existing directory
        /// </summary>
        public static DirectoryInfo EnsureAccessibleDirectory(string path)
        {
          FileSystemAccessRule ausersRule = new FileSystemAccessRule(
                      new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null), //  "Authenticated Users",
                      FileSystemRights.FullControl,
                      InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                      PropagationFlags.None,
                      AccessControlType.Allow);

          FileSystemAccessRule usersRule = new FileSystemAccessRule(
                      new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null), // "Users",
                      FileSystemRights.FullControl,
                      InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                      PropagationFlags.None,
                      AccessControlType.Allow);

          FileSystemAccessRule adminsRule = new FileSystemAccessRule(
                      new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null), // "Administrators",
                      FileSystemRights.FullControl,
                      InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                      PropagationFlags.None,
                      AccessControlType.Allow);

          FileSystemAccessRule sysRule = new FileSystemAccessRule(
                     new SecurityIdentifier(WellKnownSidType.LocalSystemSid, null), // "SYSTEM",
                     FileSystemRights.FullControl,
                     InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                     PropagationFlags.None,
                     AccessControlType.Allow);

          DirectorySecurity dirSec = new DirectorySecurity();
          dirSec.AddAccessRule(ausersRule);
          dirSec.AddAccessRule(usersRule);
          dirSec.AddAccessRule(adminsRule);
          dirSec.AddAccessRule(sysRule);

          return Directory.CreateDirectory(path, dirSec);
        }

        /// <summary>
        /// Returns true if both buffers contain the same number of the same bytes.
        /// The implementation uses quad-word comparison as much as possible for speed.
        /// Requires UNSAFE switch
        /// </summary>
        public static unsafe bool MemBufferEquals(this byte[] buf1, byte[] buf2)
        {
           if (buf1==null || buf2==null) return false;

           var len = buf1.Length;
           if (len != buf2.Length) return false;

           var len8 = len >> 3;

           fixed (byte* pb1=buf1, pb2=buf2)
           {
              byte* p1=pb1, p2=pb2;

              for (int i=0; i < len8; i++, p1+=8, p2+=8)
                if (*((long*)p1) != *((long*)p2)) return false;

              //remainders after loop

              if ((len & 4)!=0)
              {
                 if (*((int*)p1)!=*((int*)p2)) return false;
                 p1+=4; p2+=4;
              }

              if ((len & 2)!=0)
              {
                 if (*((short*)p1)!=*((short*)p2)) return false;
                 p1+=2; p2+=2;
              }

              if ((len & 1)!=0)
                if (*((byte*)p1) != *((byte*)p2)) return false;

              return true;
           }//fixed
        }


        /// <summary>
        /// Represents an ISO code as 4 byte integer filled with
        /// up to 3 ASCII chars converted to upper case, the highest byte is free to be used by the application
        /// </summary>
        public static int PackISO3CodeToInt(string iso)
        {
          if (iso.IsNullOrWhiteSpace()) return 0;

          var l = iso.Length;

          if (l>3)
            throw new NFXException(StringConsts.ARGUMENT_ERROR+"PackISO3CodeToInt(iso>3)");


          //note: ISO codes are in ASCII plane
          var isoChar0 = (byte)iso[0];
          var isoChar1 = l>1 ? (byte)iso[1] : (byte)0x00;
          var isoChar2 = l>2 ? (byte)iso[2] : (byte)0x00;

          if (isoChar0>0x60) isoChar0 -= 0x20;//convert to upper case
          if (isoChar1>0x60) isoChar1 -= 0x20;//convert to upper case
          if (isoChar2>0x60) isoChar2 -= 0x20;//convert to upper case

          var result = (isoChar2 << 16) + (isoChar1 << 8 ) + isoChar0;
          return result;
        }

        /// <summary>
        /// Unpacks an ISO code from int which was packed with PackISO3CodeToInt
        /// </summary>
        public static unsafe string UnpackISO3CodeFromInt(int iso)
        {
          if (iso==0) return null;

          char* buf = stackalloc char[3];
          char* pc = buf;

          var c =(char)(iso & 0xff);
          if (c!=0) *pc++ = c;

          c = (char)((iso>>8) & 0xff);
          if (c!=0) *pc++ = c;

          c = (char)((iso>>16) & 0xff);
          if (c!=0) *pc++ = c;

          return new string(buf);
        }

        public static byte[] ToNetworkByteOrder(this Guid guid)
        {
          var result = guid.ToByteArray();

          var t = result[3];
          result[3] = result[0];
          result[0] = t;

          t = result[2];
          result[2] = result[1];
          result[1] = t;

          t = result[5];
          result[5] = result[4];
          result[4] = t;

          t = result[7];
          result[7] = result[6];
          result[6] = t;

          return result;
        }

        public static Guid GuidFromNetworkByteOrder(this byte[] buf, int offset=0)
        {
          var a = ReadBEInt32(buf, ref offset);
          var b = ReadBEShort(buf, ref offset);
          var c = ReadBEShort(buf, ref offset);

          return new Guid(a, b, c, 
                          buf[offset++], 
                          buf[offset++], 
                          buf[offset++], 
                          buf[offset++], 
                          buf[offset++], 
                          buf[offset++], 
                          buf[offset++], 
                          buf[offset]);
        }
    }
}
