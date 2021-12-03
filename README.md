# EasyStates

by Ruta Sapokaite

A simple simulation of a shape made from a bunch of separate objects. Functionality of the design patterns used can be tested out with GUI buttons

- [x] Sigleton for the object pool in ObjectPool.cs as SetInstance() function to have one instance of the object pool that is acessable from everywhere
- [x] Object pool in ObjectPool.cs that supplies objects to JelluObject class
- [x] State to change between the components of the objects. The interface and all state classes are in States folder. States are being managed in JellyObject.cs and changed with GUI buttons
- [x] Some states use components to separate the state and the component code into smaller chunks
- [x] Method chaining to add the states to the list
- [ ] Factory?
- [ ] Clone
- [ ] Observer to display current states or just number of objects or similar
- [ ] Cycle of colors. Like day night cycle
