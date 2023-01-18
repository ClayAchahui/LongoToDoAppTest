# LongoToDoAppTest
LongoToDo is a To Do app that helps users keep a balanced life organizing themselves. This project is done using [Xamarin](https://learn.microsoft.com/es-es/xamarin/get-started/what-is-xamarin)


## Installation
- Clone the API repository
```bash
$ git clone https://github.com/fluendo/ToDoAPI.git
```
- Before run the API change to the pull request `pr/3` by ClayAchahui(the API repository has errors in the `master` branch, in the pull request the errors are fixed)
- Running the API the application will start the new service at `http://localhost:8080/api/todo`
- Clone this repository
```bash
$ git clone https://github.com/ClayAchahui/LongoToDoAppTest.git
```
- Before run the Xamarin repository go to `App.xaml.cs` file and change `isFake` parameter to `false`:
````csharp
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    RegisterViewModels(containerRegistry);
    RegisterServices(containerRegistry, isFake: true);
}
````
- If you don't change the paramater in the previous step the application will start using the fake service, but don't worry it'll work!

## Features

###List the To Do items

After you run the app you will see a list of To Do items in the screen
<br/>
<img src="https://github.com/ClayAchahui/LongoToDoAppTest/blob/main/images/list_todo.png" width="300">
<br/>

### Create a new To Do

To create a new To Do item you can tap on the `new` button
<br/>
<img src="https://github.com/ClayAchahui/LongoToDoAppTest/blob/main/images/create1.png" width="300">
<br/>
Then you will navigate to the new page. Fill the field
<br/>
<img src="https://github.com/ClayAchahui/LongoToDoAppTest/blob/main/images/create2.png" width="300">
<br/>
and then tap on the `Create` button
<br/>
<img src="https://github.com/ClayAchahui/LongoToDoAppTest/blob/main/images/create3.png" width="300">
<br/>
the app automatically will navigate back and the To Do item will appear.

### Delete a To Do item

In order te delete a To Do item you have to tap over one item like for 1 second 
<br/>
<img src="https://github.com/ClayAchahui/LongoToDoAppTest/blob/main/images/delete1.png" width="300">
<br/>
Tap over the `Delete` option and then you will see a message like the next screenshot
<br/>
<img src="https://github.com/ClayAchahui/LongoToDoAppTest/blob/main/images/delete2.png" width="300">
<br/>

### Complete To Do Item

In order te complete the task you just have to tap once over the item and check mark will appear
<br/>
<img src="https://github.com/ClayAchahui/LongoToDoAppTest/blob/main/images/completed.png" width="300">
<br/>
you can mark the To Do item like `done` or vice-versa if you like.

### Refresh the To Do list

Refresh the To Do list is easy, you just have to pull down :)

