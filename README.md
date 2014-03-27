CrudSampleMVVM
==============

just for study pourpose, a crud application for windows store 8.1 using Caliburn Micro 2.0.0-alpha2 with the MVVM approach

There is a problem passing an object from one viewmodel to another.

I'll try to use this object to initialize the view associated with the second one.


Issue
==============

TransporterListPageViewModel contains TransporterListViewModel (it's an userControl) that manage the list.
I want to select an object form the list and pass it to TransporterCrudPageViewModel.

TransporterCrudPageViewModel, as the previous one, contains an userControl TransporterFormViewModel.

I want to take a transporter (object) from the list, pass it to the CrudPage, and initialize the value of the Form.

But it's not possible with the actual solution.

Infact the value "Parameter" in TransporterCrudPageViewModel is always null.

I think that the problem is that the "Parameter" is initialized only after the ViewModel is created,
but i don't know how to fix that problem.


StackOverFlow
==============

There's a complete explaination of the problem on stackoverflow.

http://stackoverflow.com/questions/22659918/caliburn-micro-passing-object-between-viewmodel/22660638?noredirect=1#comment34540932_22660638
