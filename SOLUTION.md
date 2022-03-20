Your Solution Documentation
===========================

I'm not yet fully familiar with docker enough to create a compose up file. 
So running things in visual code is the alternative that I am going for.

Requirements:
.net 6
React, typescript
Visual Code


Instructions to run:
1. Open Task folder in Visual Code.
2. Open 2 terminals.
3. Change Directory of terminal 1 to the API folder.
	3.1 Run 'dotnet run'
4. Change Directory of terminal 2 to the client-app folder.
	4.1 Run 'npm start'


The back end solution I demonstrate the use of a CQRS pattern.
Added Serilog because it didn't take longer than a few seconds to. Already somewhat familiar with it.
The back end does not validate anything right now. 
It can be extended to use fluid validation of requests and commands. Which technically it always should unless IRequest is empty.
The api for list of jobs does not take into consideration the lenght of a requested list. It can
be modified to include a request size and skip in the request parameter.
The tables GUIDs should've been incremented ID's I realized at the end due to readability issues on front end now.
The job table's status column would probably have been better to use an enum instead of a string.

The front end is in React, typescript. Installed Semantic UI for react. While working I think I should've
gone for material UI instead. Reason to go for Semantic UI was because I touched on it recently in a tutorial.
Possible issues with Semantic UI it may not build due to a bug which I managed to fix.
Issue and fix related documentation discovered: 
(Second link the post is the one that instructs to install semantic ui patch and add to postinstall script)
https://stackoverflow.com/questions/70367443/create-react-app-with-typescript-failing-to-compile-after-importing-semantic-ui
https://github.com/Semantic-Org/Semantic-UI-React/issues/4287
The Semantic UI also already includes some of the fontawesome icons.
Extra font awesome icons had to be installed. Looking back now I probably should've spent more time on looking what came
with the Semantic UI icons instead. Now there are 2 or 3 extra packages that are not required installed.
The libraries did not include Alphabet icons. Hence use of astronaut icon. String interpolation with icon name is the asnwer here.

In regards to the written react TypeScript; 
I have yet to learn to use global state management such as MobX. That is actually next in my list to learn. 
The axios requests could've been put into an agent component, to make things cleaner.
I probably should've learned to use useMemo or setMemo for the accepted lists and new job lists.

Lists could be any length so request parameters should be used if this is expanded on.
This would also require design changes to allow users to go through pages of the list.
Introducing the option for the user to see how long the list they would like is another option,
along the infinite scroll option.
The component is modular so having it in another search component would possibly be a good approach
to allow users to filter by suburb, price, or job category.


Concerns:
The efficiency of the use of the Tabs. I am not entirely sure if the tabs are used correctly.
The way the 2 use effects are implemented in App.tsx.
The mail to and tel uses in the AcceptedJobDetails.tsx.
The use of GIT was rushed as I rushed writing the solution.
Automapper is still installed, as initial understanding of requirements was wrong.
No in code documentation. I should've documented my code.
The recreation of tables was done incorrectly. I should've learned to use docker properly
first instead of re-writing tables. The tables used in my solution have no foreign key constraints.
Using sqlite.