#region "License Agreement"
/* Skimpt, an open source screenshot utility.
      Copyright (C) <year>  <name of author>

      This program is free software: you can redistribute it and/or modify
      it under the terms of the GNU General Public License as published by
      the Free Software Foundation, either version 3 of the License, or
      (at your option) any later version.

      this program is distributed in the hope that it will be useful,
      but WITHOUT ANY WARRANTY; without even the implied warranty of
      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      GNU General Public License for more details.

      You should have received a copy of the GNU General Public License
      along with this program.  If not, see <http://www.gnu.org/licenses/>. */
#endregion
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Collections;


/// <summary>
/// converted to C# and Modified by Andy Bonner - andybonner@lycos.com
/// Modified on October 24th 2008 by Affan Shoukat to improve performance.
/// </summary>
/// 
public class FTP
{
    #region "Class Variable Declarations"
    private string m_sRemoteHost;
    private string m_sRemotePath;
    private string m_sRemoteUser;
    private string m_sRemotePassword;
    // private string m_sMess;
    private int m_iRemotePort;
    private int m_iBytes;
    private Socket m_objClientSocket;

    private int m_iRetValue;
    private bool m_bLoggedIn;
    private string m_sMes;
    private string m_sReply;

    //Set the size of the packet that is used to read and to write data to the FTP server
    //to the following specified size.
    public const int BLOCK_SIZE = 512;
    private byte[] m_aBuffer = new byte[BLOCK_SIZE + 1];
    private Encoding ASCII = Encoding.ASCII;
    public bool flag_bool;
    //General variable declaration
    private string m_sMessageString;
    #endregion

    #region " Constructors "

    public FTP()
    {
        m_sRemoteHost = "microsoft";
        m_sRemotePath = ".";
        m_sRemoteUser = "anonymous";
        m_sRemotePassword = "";
        m_sMessageString = "";
        m_iRemotePort = 21;
        m_bLoggedIn = false;
    }

    public FTP(string sRemoteHost, string sRemotePath,
        string sRemoteUser, string sRemotePassword, int iRemotePort)
    {
        m_sRemoteHost = sRemoteHost;
        m_sRemotePath = sRemotePath;
        m_sRemoteUser = sRemoteUser;
        m_sRemotePassword = sRemotePassword;
        m_sMessageString = "";
        m_iRemotePort = iRemotePort;
        m_bLoggedIn = false;
    }

    public FTP(string sRemoteHost, string sRemotePath,
    string sRemoteUser, string sRemotePassword)
    {
        m_sRemoteHost = sRemoteHost;
        m_sRemotePath = sRemotePath;
        m_sRemoteUser = sRemoteUser;
        m_sRemotePassword = sRemotePassword;
        m_sMessageString = "";
        m_iRemotePort = 21;
        m_bLoggedIn = false;
    }

    #endregion

    #region " Public Properties "

    /// Set or Get the name of the FTP server that you want to connect to.
    public string RemoteHostFTPServer
    {
        get { return m_sRemoteHost; }
        set { m_sRemoteHost = value; }
    }

    /// Set or Get the FTP port number of the FTP server that you want to connect to.
    public int RemotePort
    {
        get { return m_iRemotePort; }
        set { m_iRemotePort = value; }
    }

    /// Set or Get the remote path of the FTP server that you want to connect to.
    public string RemotePath
    {
        get { return m_sRemotePath; }
        set { m_sRemotePath = value; }
    }

    /// Set the remote password of the FTP server that you want to connect to.
    public string RemotePassword
    {
        get { return m_sRemotePassword; }
        set { m_sRemotePassword = value; }
    }

    /// Set or Get the remote user of the FTP server that you want to connect to.
    public string RemoteUser
    {
        get { return m_sRemoteUser; }
        set { m_sRemoteUser = value; }
    }

    /// Set or Get the class messagestring.
    public string MessageString
    {
        get { return m_sMessageString; }
        set { m_sMessageString = value; }
    }

    #endregion

    #region " Public Subs and Functions "

    /// Return a list of files from the file system. Return these files in a string() array.
    public string[] GetFileList(string sMask)
    {
        Socket cSocket;
        int bytes;
        char seperator = Convert.ToChar("\n");
        string[] mess;
        m_sMes = "";
        /// Check to see if you are logged on to the FTP server.

        if (!m_bLoggedIn)
        {
            Login();
        }

        cSocket = CreateDataSocket();

        /// Send an FTP command. 
        SendCommand("NLST " + sMask);

        if (!(m_iRetValue == 150 || m_iRetValue == 125))
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        m_sMes = "";

        while (true)
        {
            Array.Clear(m_aBuffer, 0, m_aBuffer.Length);
            bytes = cSocket.Receive(m_aBuffer, m_aBuffer.Length, 0);
            m_sMes += ASCII.GetString(m_aBuffer, 0, bytes);

            if (bytes < m_aBuffer.Length)
            {
                break;
            }
            System.Threading.Thread.Sleep(10);
        }

        mess = m_sMes.Split(seperator);

        cSocket.Close();
        ReadReply();

        if (m_iRetValue != 226)
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        return mess;
    }


    private struct SplitLine
    {
        public bool Valid;
        public bool Dir;
        public string FileName;
        public int FileSize;
        public string FileDate;
        public string FileTime;
    }

    /// Return a list of files & Directories from the file system.
    public void GetDirList(DirList dl)
    {
        Socket cSocket;
        int bytes;
        char seperator = Convert.ToChar("\n");
        string[] mess;

        m_sMes = "";

        /// Check to see if you are logged on to the FTP server.

        if (!m_bLoggedIn)
        {
            Login();
        }

        cSocket = CreateDataSocket();
        /// Send an FTP command. 
        SendCommand("LIST -AL");

        if (!(m_iRetValue == 150 || m_iRetValue == 125))
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        m_sMes = "";

        while (true)
        {
            Array.Clear(m_aBuffer, 0, m_aBuffer.Length);
            bytes = cSocket.Receive(m_aBuffer, m_aBuffer.Length, 0);
            m_sMes += ASCII.GetString(m_aBuffer, 0, bytes);

            if (bytes < m_aBuffer.Length)
            {
                break;
            }
            System.Threading.Thread.Sleep(10);
        }

        mess = m_sMes.Split(seperator);
        cSocket.Close();
        ReadReply();

        if (m_iRetValue != 226)
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        if (mess.Length > 0)
        {
            foreach (string tmpstr in mess)
            {
                if (tmpstr != "")
                {
                    DirFile lf;

                    SplitLine sl = ParseLine(tmpstr);

                    if (sl.Valid)
                    {
                        if (sl.Dir)
                        {
                            lf = new DirFile(sl.FileName, sl.FileDate, sl.FileTime, true, 0);
                        }
                        else
                        {
                            lf = new DirFile(sl.FileName, sl.FileDate, sl.FileTime, false, sl.FileSize);
                        }
                        dl.Add(lf);
                    }
                }
            }
        }
    }
    private SplitLine ParseLine(string Line)
    {
        SplitLine sl = new SplitLine();
        sl.Valid = false;
        Regex rx;
        Match m;

        // is it dos format?
        rx = new Regex(@"(?<Date>[0-9|-]{8})\s*(?<Time>[0-9|:|AM|PM]*)\s*(?<Size>[0-9"
            + @"|\<|\>|DIR]*)\s*(?<Name>.*)\r", RegexOptions.IgnoreCase);

        m = rx.Match(Line);
        if (m.Success)
        {
            sl.Valid = true;
            if (m.Groups["Size"].Value == "<DIR>")
            {
                sl.Dir = true;
                sl.FileSize = 0;
            }
            else
            {
                sl.Dir = false;
                sl.FileSize = Convert.ToInt32(m.Groups["Size"].Value);
            }
            sl.FileName = m.Groups["Name"].Value;
            sl.FileDate = m.Groups["Date"].Value;
            sl.FileTime = m.Groups["Time"].Value;
        }
        else
        {
            // is it unix format?
            rx = new Regex(@"(?<Dir>.{1}).{9}\s*[0-9]*\s*\w*\s*\w*\s*(?<Size>[0-9]*)\s*(?"
                + @"<Month>[a-z|A-Z]{3})\s*(?<Day>[0-9]*)\s*(?<Time>[0-9|:]*)\s*("
                + @"?<Name>.*)\r", RegexOptions.None);

            m = rx.Match(Line);
            if (m.Success)
            {
                sl.Valid = true;
                if (m.Groups["Dir"].Value == "d")
                {
                    sl.Dir = true;
                }
                else
                {
                    sl.Dir = false;
                }
                sl.FileSize = Convert.ToInt32(m.Groups["Size"].Value);
                sl.FileName = m.Groups["Name"].Value;

                if (m.Groups["Time"].Value.IndexOf(':') == -1)
                {
                    sl.FileDate = m.Groups["Day"].Value + " " + m.Groups["Month"].Value + " " + m.Groups["Time"].Value;
                    sl.FileTime = "";
                }
                else
                {
                    sl.FileDate = m.Groups["Day"].Value + " " + m.Groups["Month"].Value + " " + DateTime.Now.Year.ToString();
                    sl.FileTime = m.Groups["Time"].Value;
                }
            }
        }

        return sl;
    }


    /// Get the size of the file on the FTP server.
    public long GetFileSize(string sFileName)
    {
        long size;

        if (!m_bLoggedIn)
        {
            Login();
        }
        /// Send an FTP command. 
        SendCommand("SIZE " + sFileName);
        size = 0;

        if (m_iRetValue == 213)
        {
            size = long.Parse(m_sReply.Substring(4));
        }
        else
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        return size;
    }

    /// Log on to the FTP server.
    public bool Login()
    {
        m_objClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPEndPoint ep = new IPEndPoint(Dns.Resolve(m_sRemoteHost).AddressList[0], m_iRemotePort);

        try
        {
            m_objClientSocket.Connect(ep);
        }
        catch (Exception)
        {
            MessageString = m_sReply;
            throw new IOException("Cannot connect to the remote server");
        }

        ReadReply();
        if (m_iRetValue != 220)
        {
            CloseConnection();
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        /// Send an FTP command to send a user logon ID to the server.
        SendCommand("USER " + m_sRemoteUser);
        if (!(m_iRetValue == 331 || m_iRetValue == 230))
        {
            Cleanup();
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        if (m_iRetValue != 230)
        {
            ///Send an FTP command to send a user logon password to the server.
            SendCommand("PASS " + m_sRemotePassword);
            if (!(m_iRetValue == 230 || m_iRetValue == 202))
            {
                Cleanup();
                MessageString = m_sReply;
                throw new IOException(m_sReply.Substring(4));
            }
        }

        m_bLoggedIn = true;
        /// Call the ChangeDirectory user-defined function to change the directory to the 
        /// remote FTP folder that is mapped.
        ChangeDirectory(m_sRemotePath);

        /// Return the final result.
        return m_bLoggedIn;
    }

    /// If the value of mode is true, set binary mode for downloads. Otherwise, set ASCII mode.
    public void SetBinaryMode(bool bMode)
    {
        if (bMode)
        {
            /// Send the FTP command to set the binary mode.
            /// (TYPE is an FTP command that is used to specify representation type.)
            SendCommand("TYPE I");
        }
        else
        {
            /// Send the FTP command to set ASCII mode. 
            /// (TYPE is an FTP command that is used to specify representation type.)
            SendCommand("TYPE A");
        }

        if (m_iRetValue != 200)
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }
    }

    ///  Download a file to the local directory of the assembly. Keep the same file name.
    public void DownloadFile(string sFileName)
    {
        DownloadFile(sFileName, "", false);
    }

    /// Download a remote file to the local directory of the Assembly. Keep the same file name.
    public void DownloadFile(string sFileName, bool bResume)
    {
        DownloadFile(sFileName, "", bResume);
    }

    /// Download a remote file to a local file name. You must include a path.
    /// The local file name will be created or will be overwritten, but the path must exist.
    public void DownloadFile(string sFileName, string sLocalFileName)
    {
        DownloadFile(sFileName, sLocalFileName, false);
    }


    /// Download a remote file to a local file name. You must include a path. Set the 
    /// resume flag. The local file name will be created or will be overwritten, but the path must exist.
    public void DownloadFile(string sFileName, string sLocalFileName, bool bResume)
    {
        Stream st;
        FileStream output;
        Socket cSocket;
        long offset;
        //long npos;

        if (!m_bLoggedIn)
        {
            Login();
        }

        SetBinaryMode(true);

        if (sLocalFileName.Equals(""))
        {
            sLocalFileName = sFileName;
        }

        if (!File.Exists(sLocalFileName))
        {
            st = File.Create(sLocalFileName);
            st.Close();
        }

        output = new FileStream(sLocalFileName, FileMode.Open);
        cSocket = CreateDataSocket();
        offset = 0;

        if (bResume)
        {
            offset = output.Length;

            if (offset > 0)
            {
                /// Send an FTP command to restart.
                SendCommand("REST " + offset);
                if (m_iRetValue != 350)
                {
                    offset = 0;
                }
            }

            if (offset > 0)
            {
                //npos = output.Seek(offset, SeekOrigin.Begin);
            }
        }

        /// Send an FTP command to retrieve a file.
        SendCommand("RETR " + sFileName);

        if (!(m_iRetValue == 150 || m_iRetValue == 125))
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        while (true)
        {
            Array.Clear(m_aBuffer, 0, m_aBuffer.Length);
            m_iBytes = cSocket.Receive(m_aBuffer, m_aBuffer.Length, 0);
            output.Write(m_aBuffer, 0, m_iBytes);

            if (m_iBytes <= 0)
            {
                break;
            }
        }

        output.Close();

        if (cSocket.Connected)
        {
            cSocket.Close();
        }

        ReadReply();
        if (!(m_iRetValue == 226 || m_iRetValue == 250))
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

    }

    /// This is a function that is used to upload a file from your local hard disk
    /// to your FTP site.
    public void UploadFile(string sFileName)
    {
        UploadFile(sFileName, false);
    }

    /// This is a function that is used to upload a file from your local hard disk
    ///  to your FTP site and then set the resume flag.
    public void UploadFile(string sFileName, bool bResume)
    {
        Socket cSocket;
        long offset;
        FileStream input;
        bool bFileNotFound;

        if (!m_bLoggedIn)
        {
            Login();
        }

        cSocket = CreateDataSocket();
        offset = 0;

        if (bResume)
        {
            try
            {
                SetBinaryMode(true);
                offset = GetFileSize(sFileName);
            }
            catch (Exception)
            {
                offset = 0;
            }
        }

        if (offset > 0)
        {
            SendCommand("REST " + offset);
            if (m_iRetValue != 350)
            {
                /// The remote server may not support resuming.
                offset = 0;
            }
        }

        /// Send an FTP command to store a file.
        SendCommand("STOR " + Path.GetFileName(sFileName));
        if (!(m_iRetValue == 125 || m_iRetValue == 150))
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        /// Check to see if the file exists before the upload.
        bFileNotFound = false;
        if (File.Exists(sFileName))
        {
            /// Open the input stream to read the source file.
            input = new FileStream(sFileName, FileMode.Open);
            if (offset != 0)
            {
                input.Seek(offset, SeekOrigin.Begin);
            }

            /// Upload the file. 
            m_iBytes = input.Read(m_aBuffer, 0, m_aBuffer.Length);
            while (m_iBytes > 0)
            {
                cSocket.Send(m_aBuffer, m_iBytes, 0);
                m_iBytes = input.Read(m_aBuffer, 0, m_aBuffer.Length);
            }
            input.Close();
        }
        else
        {
            bFileNotFound = true;
        }

        if (cSocket.Connected)
        {
            cSocket.Close();
        }

        /// Check the return value if the file was not found.
        if (bFileNotFound)
        {
            MessageString = m_sReply;
            throw new IOException("The file: " + sFileName + " was not found. Cannot upload the file to the FTP site");
        }

        ReadReply();
        if (!(m_iRetValue == 226 || m_iRetValue == 250))
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }
    }

    /// Delete a file from the remote FTP server.
    public bool DeleteFile(string sFileName)
    {
        bool bResult;

        bResult = true;
        if (!m_bLoggedIn)
        {
            Login();
        }
        /// Send an FTP command to delete a file.
        SendCommand("DELE " + sFileName);
        if (m_iRetValue != 250)
        {
            bResult = false;
            MessageString = m_sReply;
        }

        /// Return the final result.
        return bResult;
    }

    /// Rename a file on the remote FTP server.
    public bool RenameFile(string sOldFileName, string sNewFileName)
    {
        bool bResult = true;

        if (!m_bLoggedIn)
        {
            Login();
        }
        /// Send an FTP command to rename from a file.
        SendCommand("RNFR " + sOldFileName);
        if (m_iRetValue != 350)
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        /// Send an FTP command to rename a file to a new file name.
        /// It will overwrite if newFileName exists. 
        SendCommand("RNTO " + sNewFileName);
        if (m_iRetValue != 250)
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }
        /// Return the final result.
        return bResult;
    }

    /// This is a function that is used to create a directory on 
    /// the remote FTP server.
    public bool CreateDirectory(string sDirName)
    {
        bool bResult = true;

        if (!m_bLoggedIn)
        {
            Login();
        }
        /// Send an FTP command to make directory on the FTP server.
        SendCommand("MKD " + sDirName);
        if (m_iRetValue != 257)
        {
            bResult = false;
            MessageString = m_sReply;
        }

        /// Return the final result.
        return bResult;
    }

    /// This is a function that is used to delete a directory on 
    /// the remote FTP server.
    public bool RemoveDirectory(string sDirName)
    {
        bool bResult = true;

        /// Check if logged on to the FTP server
        if (!m_bLoggedIn)
        {
            Login();
        }
        /// Send an FTP command to remove directory on the FTP server.
        SendCommand("RMD " + sDirName);
        if (m_iRetValue != 250)
        {
            bResult = false;
            MessageString = m_sReply;
        }

        /// Return the final result.
        return bResult;
    }

    /// This is a function that is used to change the current working
    /// directory on the remote FTP server.
    public bool ChangeDirectory(string sDirName)
    {
        bool bResult = true;

        /// Check if you are in the root directory.
        if (sDirName.Equals("."))
        {
            return false;
        }
        /// Check if logged on to the FTP server
        if (!m_bLoggedIn)
        {
            Login();
        }
        /// Send an FTP command to change directory on the FTP server.
        SendCommand("CWD " + sDirName);
        if (m_iRetValue != 250)
        {
            bResult = false;
            MessageString = m_sReply;
            throw new DirectoryNotFoundException("Cannot find directory : " + sDirName);
        }

        m_sRemotePath = sDirName;

        /// Return the final result.
        return bResult;
    }

    ///  Close the FTP connection of the remote server.
    public void CloseConnection()
    {
        if (m_objClientSocket != null)
        {
            /// Send an FTP command to end an FTP server system.
            SendCommand("QUIT");
        }

        Cleanup();
    }

    #endregion

    #region " Private Subs and Functions "

    /// Read the reply from the FTP server.
    private void ReadReply()
    {
        m_sMes = "";
        m_sReply = ReadLine(false);
        m_iRetValue = int.Parse(m_sReply.Substring(0, 3));
    }

    /// Clean up some variables.
    private void Cleanup()
    {
        if (m_objClientSocket != null)
        {
            m_objClientSocket.Close();
            m_objClientSocket = null;
        }

        m_bLoggedIn = false;
    }

    /// Read a line from the FTP server.
    private string ReadLine(bool bClearMes)
    {
        char seperator = Convert.ToChar("\n");
        string[] mess;

        if (bClearMes)
        {
            m_sMes = "";
        }

        while (true)
        {
            Array.Clear(m_aBuffer, 0, BLOCK_SIZE);
            m_iBytes = m_objClientSocket.Receive(m_aBuffer, m_aBuffer.Length, 0);
            m_sMes += ASCII.GetString(m_aBuffer, 0, m_iBytes);
            if (m_iBytes < m_aBuffer.Length)
            {
                break;
            }
        }

        mess = m_sMes.Split(seperator);
        if (m_sMes.Length > 2)
        {
            m_sMes = mess[mess.Length - 2];
        }
        else
        {
            m_sMes = mess[0];
        }

        if (!m_sMes.Substring(3, 1).Equals(" "))
        {
            return ReadLine(true);
        }

        return m_sMes;
    }

    ///  This is a function that is used to send a command to the FTP server that you are connected to.
    private void SendCommand(string sCommand)
    {
        sCommand = sCommand + "\r\n";
        byte[] cmdbytes = ASCII.GetBytes(sCommand);
        m_objClientSocket.Send(cmdbytes, cmdbytes.Length, 0);
        ReadReply();
    }

    /// Create a data socket.
    private Socket CreateDataSocket()
    {
        int index1;
        int index2;
        int len;
        int partCount;
        int i;
        int port;
        string ipData;
        string buf;
        string ipAddress;
        int[] parts = new int[7];
        char ch;
        Socket s;
        IPEndPoint ep;

        /// Send an FTP command to use passive data connection. 
        SendCommand("PASV");
        if (m_iRetValue != 227)
        {
            MessageString = m_sReply;
            throw new IOException(m_sReply.Substring(4));
        }

        index1 = m_sReply.IndexOf("(");
        index2 = m_sReply.IndexOf(")");
        ipData = m_sReply.Substring(index1 + 1, index2 - index1 - 1);

        len = ipData.Length;
        partCount = 0;
        buf = "";

        for (i = 0; i <= (len - 1); i++)
        {
            if (partCount > 6)
            {
                break;
            }

            ch = char.Parse(ipData.Substring(i, 1));
            if (char.IsDigit(ch))
            {
                buf += ch;
            }
            else if (ch != Convert.ToChar(","))
            {
                MessageString = m_sReply;

                throw new IOException("Malformed PASV reply: " + m_sReply);
            }

            if ((ch == Convert.ToChar(",")) | (i + 1 == len))
            {
                try
                {
                    parts[partCount] = int.Parse(buf);
                    partCount += 1;
                    buf = "";
                }
                catch (Exception)
                {
                    MessageString = m_sReply;
                    throw new IOException("Malformed PASV reply: " + m_sReply);
                }
            }
        }

        ipAddress = parts[0] + "." + parts[1] + "." + parts[2] + "." + parts[3];

        /// Make this call in Visual Basic .NET 2002. You want to 
        /// bitshift the number by 8 bits. In Visual Basic .NET 2002 you must
        /// multiply the number by 2 to the power of 8.
        /// port = parts(4) * (2 ^ 8)

        /// Make this call and then comment out the previous line for
        /// Visual Basic .NET 2003.
        port = parts[4] << 8;

        /// Determine the data port number.
        port = port + parts[5];

        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        ep = new IPEndPoint(Dns.Resolve(ipAddress).AddressList[0], port);

        try
        {
            s.Connect(ep);
        }
        catch (Exception)
        {
            MessageString = m_sReply;
            flag_bool = false;
            throw new IOException("Cannot connect to remote server.");
            /// If you cannot connect to the FTP server that is 
            /// specified, make the boolean variable false.
        }

        /// If you can connect to the FTP server that is specified,
        /// make the boolean variable true.
        flag_bool = true;
        return s;
    }

    #endregion
}

public class DirFile : IComparable
{
    private string _Name;
    private bool _IsDir;
    private string _Date;
    private string _Time;
    private int _Size;

    public string Name { get { return _Name; } }
    public bool IsDir { get { return _IsDir; } }
    public string FileDate { get { return _Date; } }
    public string FileTime { get { return _Time; } }
    public int FileSize { get { return _Size; } }

    public DirFile(string Name, string FDate, string FTime, bool Dir, int FSize)
    {
        _Name = Name;
        _Date = FDate;
        _Time = FTime;
        _IsDir = Dir;
        _Size = FSize;
    }

    public int CompareTo(object obj)
    {
        DirFile df;

        // Any non-Nothing object is greater than nothing.
        if (obj == null)
        {
            return 1;
        }

        // Avoid late-binding and cast to a specific Person Object.
        df = ((DirFile)(obj));

        // Use the String's CompareTo Method to perform the check.
        return this.IsDir.CompareTo(df.IsDir);
    }
}

public class DirList : CollectionBase
{
    // Create the Default Property Item for this collection.
    // Allow the retrieval by index.
    public DirFile this[int index]
    {
        get
        {
            // Avoid Late-binding and return this as a DirFile Object
            return ((DirFile)(this.InnerList[index]));
        }
    }

    // Create another default property for this collection.
    // Allow retrieval by name.
    public DirFile this[string Instance]
    {
        get
        {
            DirFile df;
            foreach (DirFile tempLoopVar_df in this.InnerList)
            {
                df = tempLoopVar_df;
                if (df.Name == Instance)
                {
                    // We found our DirFile object, return it.
                    return df;
                }
            }
            return null;
        }
    }

    // Create another property for this collection.
    // Allows checking for existance by name.
    bool Exists(string Instance)
    {
        DirFile df;
        foreach (DirFile tempLoopVar_df in this.InnerList)
        {
            df = tempLoopVar_df;
            if (df.Name == Instance)
            {
                // We found our DirFile object, return it.
                return true;
            }
        }
        return false;
    }

    // Create a new instance of our Collection, by calling MyBase.New
    public DirList()
    {
    }

    protected override void OnSet(int index, object oldValue, object newValue)
    {
        if (!(newValue is DirFile))
        {
            throw (new ArgumentException(string.Format("Cannot add a {0} type to this collection", newValue.GetType().ToString()), "Value"));
        }
    }

    protected override void OnInsert(int index, object value)
    {
        if (!(value is DirFile))
        {
            throw (new ArgumentException(string.Format("Cannot add a {0} type to this collection", value.GetType().ToString()), "Value"));
        }
    }

    protected override void OnRemove(int index, object value)
    {
        if (!(value is DirFile))
        {
            throw (new ArgumentException(string.Format("Cannot add a {0} type to this collection", value.GetType().ToString()), "Value"));
        }
    }

    // Method to add a single DirFile object to our collection.
    public int Add(DirFile value)
    {
        return this.InnerList.Add(value);
    }

    // Method to Remove a specific DirFile object from our collection.
    public void Remove(DirFile value)
    {
        this.InnerList.Remove(value);
    }

    // Method to check if a DirFile object already exists in the collection.
    public bool Contains(DirFile value)
    {
        return this.Contains(value);
    }

    // Create the Sort method for the collection.
    public void Sort()
    {
        this.InnerList.Sort();
    }
}

