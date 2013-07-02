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
 * Date: 16/5/2013
 * Time: 5:20 PM
 * Version: 1.0.0
 * 
 */

namespace citrus.lemonlime
{
	public abstract class DBServerConfig : IDatabaseConfiguration
	{
		public string Hostname
		{
			get { return hostname; }
			set { hostname = value; }
		}

		public ushort Port {
			get { return port; }
			set { port = value; }
		}

		public string Database
		{
			get { return database; }
			set { database = value; }
		}

		public string Username
		{
			get { return username; }
			set { username = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public DBServerConfig(String hostname, ushort port, String database, String username, String password) {
			this.Hostname = hostname;
			this.Port = port;
			this.Database = database;
			this.Username = username;
			this.Password = password;
		}

		private string hostname;
		private ushort port;
		private string database;
		private string username;
		private string password;
	}
}
