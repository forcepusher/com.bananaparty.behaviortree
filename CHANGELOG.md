# Changelog  
All notable changes to this project will be documented in this file.  
  
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),  
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).  
  
## [6.1.0] - 2025-02-13  
### Added  
- Added Override node.  
- Added ReactiveReset node, which is a special node with only 2 children that resemble condition and action.
  Sample use for ReactiveReset would be a melee game where you need to restart a knockback sequence while already playing it, so every hit triggers a knockback.  
  
## [6.0.2] - 2025-01-23  
### Fixed  
- Fixed Parallel Composites to not execute child nodes that have already finished with either Success or Failure.  
  
## [6.0.1] - 2024-12-21  
### Fixed  
- Fixed Parallel Composites so they properly reset their children on either completion or interruption.  
  
## [6.0.0] - 2024-07-04  
### Removed  
- Removed `RollbackNodes`. This feature is completely cut from the package, since nobody used it.  
  
### Changed  
- `Execute(long time)` is changed to `Execute(float deltaTime)`. Time parameter now has different semantics. It's `Time.deltaTime` rather `Time.realTimeSinceStartup`. Executing your tree should be like `behaviorTree.Execute(Time.deltaTime);`.  
- Renamed all standard nodes so they don't end with a `Node` word, as well as other similar renames to reduce constructor code length.  
- Disabled NoEngineReferences option in assembly settings since it only made debugging more difficult.  
  
[6.1.0] https://github.com/forcepusher/com.bananaparty.behaviortree/compare/6.0.2...6.1.0  
[6.0.2] https://github.com/forcepusher/com.bananaparty.behaviortree/compare/6.0.1...6.0.2  
[6.0.1] https://github.com/forcepusher/com.bananaparty.behaviortree/compare/6.0.0...6.0.1  
[6.0.0] https://github.com/forcepusher/com.bananaparty.behaviortree/compare/5.2.0...6.0.0  
