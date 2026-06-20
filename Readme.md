# Discord Chat Exporter

**A simple, yet powerful tool to export message history from any Discord channel to a file.**

This program allows you to download chat history from Discord servers and Direct Messages. It exports your conversations significantly faster and more reliably than manual copying, saving them in formats like HTML, TXT, CSV, or JSON.

---

## ✨ Features

-   **Graphical Interface**: A clean, modern Windows application that is easy to use.
-   **⭐ Favorites System**: Mark your most important channels across different servers as favorites. View and export them all from a single list!
-   **Multiple Export Formats**:
    -   **HTML (Dark/Light)**: Looks just like Discord! Great for reading.
    -   **TXT**: Plain text, good for searching and archiving.
    -   **CSV / JSON**: Structured data for developers or analysis.
-   **Rich Media Support**: Downloads images, videos, emojis, and renders markdown correctly.
-   **Flexible Filtering**: Export by date range, partition by size, or filter specific messages.
-   **Cross-Platform Core**: While the GUI is designed for Windows, the underlying engine supports Docker, macOS, and Linux (via CLI).

---

## 🚀 Getting Started

### Prerequisites

To run this application, you need **Windows** and the **.NET 10 Desktop Runtime**.
> [!TIP]
> **Download .NET 10 Desktop Runtime here:** [Microsoft .NET Download Page](https://dotnet.microsoft.com/download/dotnet/10.0) -> Look for ".NET Desktop Runtime" under Windows.

### Installation

1.  **Download**: Go to the **Releases** page (on the right side of GitHub) and download the latest `DiscordChatExporter.zip`.
2.  **Unzip**: Right-click the downloaded file and select **Extract All**. *Do not run the program directly inside the zip file.*
3.  **Run**: Open the extracted folder and double-click `DiscordChatExporter.exe`.

---

## 📖 How to Use

### 1. Authentication
To access your chats, the program needs a **Token**. This is your personal access key.
-   **Automatic**: Detailed instructions on how to get your token are available in the [Token Guide](https://github.com/Tyrrrz/DiscordChatExporter/blob/master/.docs/Token-and-IDs.md).
-   **Paste Token**: Copy your token into the box at the top of the program and press the `→` (Arrow) button or `Enter`.

### 2. Selecting Channels
Once logged in, you will see a list of servers on the left.
-   **Servers**: Click a server icon to see its channels.
-   **Direct Messages**: Click the Discord icon (top left) to see your private chats.
-   **⭐ Favorites**: Click the **Star Icon** at the top of the server list to see all your favorited channels in one place.

### 3. Managing Favorites (New!)
You can now organize channels from different servers into one easy-to-access list.
-   **Add to Favorites**: In any channel list, click the **Star** icon next to a channel name. It will turn Gold ⭐️.
-   **View Favorites**: Click the **Star Server** at the top of the left sidebar.
-   **Export Favorites**: Select channels in the Favorites view to export them all at once, even if they belong to different servers.

### 4. Exporting
1.  **Select**: Click on the channels you want to export (hold `Ctrl` to select multiple).
2.  **Download**: Click the **Download Button** (bottom right corner).
3.  **Configure**:
    -   **Output Format**: HTML (Dark) is recommended for best viewing.
    -   **Directory**: Choose where to save the files.
    -   **Assets**: Check "Download Assets" if you want images and profile pictures saved locally (offline view).
4.  **Start**: Click **Export** and watch the progress bars!

---

## 🛠 Advanced Usage (CLI)

For developers or server automation, a Command-Line Interface (CLI) is included.

```bash
# Example: Export a channel to HTML
dotnet DiscordChatExporter.Cli.dll export -t "YOUR_TOKEN" -c "CHANNEL_ID" -f HtmlDark
```

Run `dotnet DiscordChatExporter.Cli.dll --help` to see all available commands.

---

## ❓ Troubleshooting

**"The application won't start"**
*   Please verify you have installed the [.NET 10 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/10.0).
*   Try running the `.exe` as Administrator.

**"Access Denied" or "401 Unauthorized"**
*   Your Token might have expired or changed (this happens if you change your password). Please get a fresh token.
*   Make sure you have access to the channel you are trying to export.

See the [Changelog](CHANGELOG.md) for details on recent updates. Released under the [MIT License](License.txt).

*This project is built with ❤️ using C#, Avalonia UI, and .NET 10.*
