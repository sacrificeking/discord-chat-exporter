# Changelog

All notable changes to this project will be documented in this file.

## [1.1.0] - 2026-06-20

### Added
- **.NET 10.0 Migration**: Upgraded the target framework for the entire solution (`Core`, `Cli`, `Gui`, `Tests`) to target `.NET 10.0`, ensuring compatibility with the latest C# language features and compiler optimizations.
- **Docker & CI Updates**: Updated GitHub Actions build workflows and the Dockerfile environment to utilize official `.NET 10` SDK and Alpine-based runtime base images.

### Improved & Optimized
- **Dependency Upgrades**:
  - Upgraded **CliFx** to version `3.0.0`, switching the CLI command binding and validation from runtime reflection to compile-time Roslyn source-generators for faster execution and native AOT compatibility.
  - Upgraded **Avalonia UI** to version `12.0.4` to take advantage of the latest UI toolkit performance updates, bugs fixes, and API enhancements.
  - Upgraded **Material.Avalonia** to version `3.17.0` and **Material.Icons.Avalonia** to `3.0.2` for improved visual style components and icons in the GUI.
  - Upgraded all other core libraries (including `AsyncKeyedLock` to `8.0.2`, `YoutubeExplode` to `6.6.0`, `Polly` to `8.7.0`, and test framework libraries to their latest versions).
- **Code Refactoring & Fixes**:
  - Refactored all CLI command classes to support source-generated properties (mutable `{ get; set; }` parameters instead of immutable `init` properties).
  - Ported custom CLI binding converters (`ThreadInclusionModeBindingConverter` and `TruthyBooleanBindingConverter`) to the new `InputConverter<T>` API.
  - Resolved namespace collisions in `SuperpowerExtensions` by relying on native `.Text()` combinators.
  - Cleaned up obsolete Avalonia 11 properties in the GUI, adopting `TopLevel.GetTopLevel` instead of `GetVisualRoot` and utilizing `PlaceholderText` instead of `Watermark`.
- **Pre-compiled Releases**: Refreshed the pre-compiled `DiscordChatExporter_Release.zip` for Windows (win-x64) as an optimized, trimmed self-contained build running on the .NET 10 runtime.

## [1.0.0] - 2026-06-19

This is the initial release of **Discord Chat Exporter** under the **sacrificeking** repository. This release includes significant upgrades, performance improvements, and new features.

### Added
- **.NET 9 Support**: Upgraded the entire project to target the latest .NET 9.0 Desktop Runtime and console environment for improved performance and modern C# 13 features.
- **Favorites System**: Easily mark your most important channels across different servers as favorites. View and export them all from a single consolidated list in the GUI.
- **Include Threads in CLI**: Added support for `--include-threads` in the `export` command to easily export thread channels alongside their parent channels.
- **Predictable Unnamed Group DMs**: Names assigned to unnamed group DMs are now predictable and consistent.

### Improved & Optimized
- **Avalonia UI 11.3.0**: Upgraded GUI components to use Avalonia 11.3.0 and optimized asynchronous image loading for smooth UI rendering under heavy loads.
- **Performance Optimizations**: 
  - Changed `InvalidFileNameChars` lookup implementation to use `.NET` `FrozenSet` instead of `HashSet` for faster character escaping performance.
  - Efficient asynchronous stream writing with `IAsyncEnumerable<T>` to maintain low memory consumption during massive exports.
- **Connection Resilience**: Integrated Polly resilience pipelines for handling rate-limits via Discord's `Retry-After` headers and automated retry on transient network errors.

### Fixed
- Fixed authentication headers validation to support tokens with special characters.
