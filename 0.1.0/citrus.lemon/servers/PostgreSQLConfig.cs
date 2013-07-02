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
 * Time: 7:49 AM
 * Version: 1.0.0
 * 
 */

using System;
using System.Text;
using citrus.lemonlime;

namespace citrus.lemon.servers
{
	public sealed class PostgreSQLConfig : DBServerConfig
	{
		public override string ToString() {
			StringBuilder connectionString = new StringBuilder();

			connectionString.Append("Server=" + this.Hostname + ";");

			if (this.Port == 5432) {
				connectionString.Append("Port=5432;");
			} else {
				connectionString.Append("Port=" + this.Port + ";");
			}

			connectionString.Append("Database=" + this.Database + ";");
			connectionString.Append("Uid=" + this.Username + ";");
			connectionString.Append("Pwd=" + this.Password + ";");

			if (this.WindowsSecurity == true) {
				connectionString.Append("Integrated Security=true;");
			}

			if (this.CommandTimeout > 0) {
				connectionString.Append("CommandTimeout=" + this.CommandTimeout + ";");
			}

			if (this.ConnectionTimeout > 0) {
				connectionString.Append("ConnectionTimeout=" + this.ConnectionTimeout + ";");
			}

			if (this.ProtocolVersion == 2 || this.ProtocolVersion == 3) {
				connectionString.Append("Protocol=" + this.ProtocolVersion + ";");
			}

			if (this.SSL == true) {
				connectionString.Append ("SSL=true;SslMode=Require;");
			}

			if (this.Pooling == true) {
				connectionString.Append ("Pooling=true;MinPoolSize=" + this.MinimumPoolSize + ";");
				connectionString.Append ("MaxPoolSize=" + this.MaximumPoolSize + ";");
				connectionString.Append ("ConnectionLifeTime=" + this.ConnectionLifeTime + ";");
			}

			return connectionString.ToString();
		}

		public bool WindowsSecurity {
			get { return windowsSecurity; }
			set { windowsSecurity = value; }
		}

		public uint CommandTimeout {
			get { return commandTimeout; }
			set { commandTimeout = value; }
		}

		public uint ConnectionTimeout {
			get { return connectionTimeout; }
			set { connectionTimeout = value; }
		}

		public byte ProtocolVersion {
			get { return protocolVersion; }
			set { protocolVersion = value; }
		}

		public bool SSL {
			get { return ssl; }
			set {
				ssl = value;

				if (value == true) {
					this.ProtocolVersion = 3;
				} else {
					this.ProtocolVersion = 0;
				}
			}
		}

		public bool Pooling {
			get { return pooling; }
			set {
				pooling = value;

				if (value == true) {
					this.ProtocolVersion = 3;
				} else {
					this.ProtocolVersion = 0;
				}
			}
		}

		public ushort MinimumPoolSize {
			get { return minPoolSize; }
			set {
				if (value > 0) {
					minPoolSize = value;
				}
			}
		}

		public ushort MaximumPoolSize {
			get { return maxPoolSize; }
			set {
				if (value > minPoolSize) {
					maxPoolSize = value;
				}
			}
		}

		public ushort ConnectionLifeTime {
			get { return connectionLifetime; }
			set {
				if (value > 0) {
					connectionLifetime = value;
				}
			}
		}

		public PostgreSQLConfig() {
			this.Port = 5432;
		}

		public PostgreSQLConfig(String hostname, String database, String username, String password)
			: base(hostname, 5432, database, username, password) { }

		public PostgreSQLConfig(String hostname, ushort port, String database, String username, String password)
			: base(hostname, port, database, username, password) { }

		private bool windowsSecurity = false;
		private uint commandTimeout = 0;
		private uint connectionTimeout = 0;
		private byte protocolVersion = 0;
		private bool ssl = false;
		private bool pooling = false;
		private ushort minPoolSize = 1;
		private ushort maxPoolSize = 20;
		private uint connectionLifetime = 15;
}
