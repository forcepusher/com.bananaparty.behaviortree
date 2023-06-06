# com.bananaparty.behaviortree  
  
Unity package. Fully cross-platform Behavior Tree.  
Does not reference Unity Engine, so it could be used in a regular C# project.  
  
Make sure you have standalone [Git](https://git-scm.com/downloads) installed first. Reboot after installation.  
In Unity, open "Window" -> "Package Manager".  
Click the "+" sign on top left corner -> "Add package from git URL..."  
Paste this: `https://github.com/forcepusher/com.bananaparty.behaviortree.git#4.0.0`  
See minimum required Unity version in the `package.json` file.  
  
### Key differences from BehaviorTree in UnrealEngine, BehaviorDesigner, and NodeCanvas:  
1. Strict OOP architecture and minimalism.  
	- Trees are built by using nested constructors. Beware, it's all code.  
2. There are only 2 node callbacks, `OnExecute` and `OnReset`.  
	- Determining whether a node just started executing in `OnExecute` or being interrupted in `OnReset` is accomplished by comparing the current `BehaviorNode.Status`.  
3. Reactive Evaluation/Conditional Aborts/Observer Aborts are implemented similarly to how it's done in [NodeCanvas](https://nodecanvas.paradoxnotion.com/documentation/?section=reactive-evaluation) rather than in [BehaviorDeisgner](https://opsive.com/support/documentation/behavior-designer/conditional-aborts/) or [UnrealEngine](https://www.kodeco.com/238-unreal-engine-4-tutorial-artificial-intelligence#toc-anchor-024).  
	- However, there is no separation between ActionNodes and ConditionNodes. In case of multiple Actions in a self-interrupting Sequence (`ReactiveSequenceNode`), you would need to group them togehter into an additional Sequence.  
4. Designed with [Prediction-Rollback](https://www.youtube.com/watch?v=0NLe4IpdS1w&t=91s) network code in mind.  
	- Currently, there are only a few RollbackNodes utilizing the Memento pattern, but there are plans for expansion.  
5. Text-based visualization.  
	- Execution status of an entire tree could be viewed in a build.  
  
The library assumes that you're familiar with OOP and BehaviorTrees (which is a very bad assumption).  
There are no Samples yet, refer to the Tests folder instead. Onboarding will be improved in the future.
