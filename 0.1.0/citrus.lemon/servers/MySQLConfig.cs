/**
 * 
 * Copyright (c) 2013 Marlon Janssen Arao
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * 
 * 
 * Author: MJ Arao
 * Date: 28/6/2013
 * Time: 7:30 AM
 * Version: 1.0.0
 * 
 */

using System;
using System.Text;
using citrus.lemonlime;

namespace citrus.lemon.servers
{
	public enum MySQLEncryption { DISABLE, PREFERRED, REQUIRED };

	public class MySQLConfig : DBServerConfig
	{
		public override string ToString() {
			StringBuilder connectionString = new StringBuilder();

			connectionString.Append("Server=" + this.Hostname + ";");

			if (this.Port != 3306) {
				connectionString.Append("Port=" + this.Port + ";");
			}

			connectionString.Append("Database=" + this.Database + ";");
			connectionString.Append("Uid=" + this.Username + ";");
			connectionString.Append("Pwd=" + this.Password + ";");

			if (this.SSLMode == MySQLEncryption.PREFERRED) {
				connectionString.Append("SslMode=Preferred;");
			} else if (this.SSLMode == MySQLEncryption.REQUIRED) {
				connectionString.Append("SslMode=Required;");
			}

			return connectionString.ToString();
		}

		public MySQLEncryption SSLMode {
			get { return sslMode; }
			set { sslMode = value; }
		}

		public MySQLConfig() {
			this.Port = 3306;
		}

		public MySQLConfig(String hostname, String schema, String username, String password)
			: base(hostname, 3306, database, username, password) { }

		public MySQLConfig(String hostname, ushort port, String schema, String username, String password)
			: base(hostname, port, database, username, password) { }

		private MySQLEncryption sslMode = MySQLEncryption.DISABLE;
	}
}
