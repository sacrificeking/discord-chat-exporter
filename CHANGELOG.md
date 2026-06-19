# Changelog

All notable changes to this project will be documented in this file.

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
