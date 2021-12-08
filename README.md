# EasyStates

by Ruta Sapokaite

A simple simulation of a shape made from a bunch of separate objects. Functionality of the design patterns used can be tested out with GUI buttons

- [x] Sigleton for the object pool in ObjectPool.cs as Instance to have one instance of the object pool that is acessable from everywhere
- [x] Object pool in ObjectPool.cs that supplies objects to JellyObject class
- [x] State to change between the states of the object. The interface and all state classes are in States folder. States are being managed in JellyObject.cs and changed with GUI buttons
- [x] Command pattern to call functions on GUI buttons. The interface and all command classes are in Commands folder. Commands are being managed in JellyObject.cs and called with GUI buttons
- [x] Method chaining to add the states to the list in JellyObject.cs
- [x] All command classes that inherit from ICommand.cs use dependency injection to get components

![image](https://user-images.githubusercontent.com/31730144/145170742-2995fd7c-58f0-4721-9e87-0dfece28e541.png)
