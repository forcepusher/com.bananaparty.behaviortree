# Changelog  
All notable changes to this project will be documented in this file.  
  
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),  
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).  
  
## [6.0.0] - 2024-07-04  
### Removed  
- Removed `RollbackNodes`. This feature is completely cut from the package, since nobody used it.  
  
### Changed  
- `Execute(long time)` is changed to `Execute(float deltaTime)`. Time parameter now has different semantics. It's Time.deltaTime rather Time.realTimeSinceStartup. Executing your tree should be like `behaviorTree.Execute(Time.deltaTime);`.  
- Renamed all standard nodes so they don't end with a `Node` word, as well as other similar renames to reduce constructor code length.  
- Disabled NoEngineReferences option in assembly settings since it only made debugging more difficult.  
  
[6.0.0] https://github.com/forcepusher/com.bananaparty.behaviortree/compare/5.2.0...6.0.0  
