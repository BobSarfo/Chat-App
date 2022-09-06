# Chat Project [![Run Unit](https://github.com/alvinmarshall/ChatChallenge/actions/workflows/pull-request-build.yaml/badge.svg)](https://github.com/alvinmarshall/ChatChallenge/actions/workflows/pull-request-build.yaml)

## Table of contents  
1. [Mandatory Features](#assignment)  
2. [Bonus (Optional) Features](#bonus-optional)  
3. [Sub paragraph](#)
4. [Another paragraph](#paragraph2)  


## Assignment
---
The goal of this exercise is to create a simple browser-based chat application using .NET.
This application should allow several users to talk in a chatroom and also to get stock quotes from an API using a specific command.

Mandatory Features
---
* Allow registered users to log in and talk with other users in a chatroom.
* Allow users to post messages as commands into the chatroom with the following format
/stock=stock_code
* Create a decoupled bot that will call an API using the stock_code as a parameter
[API Link Here](https://stooq.com/q/l/?s=aapl.us&f=sd2t2ohlcv&h&e=csv), here aapl.us is the
stock_code)
* The bot should parse the received CSV file and then it should send a message back into
the chatroom using a message broker like RabbitMQ. The message will be a stock quote using the following format: “APPL.US quote is $93.42 per share”. The post owner will be the bot.
* Have the chat messages ordered by their timestamps and show only the last 50 messages.
* Unit test the functionality you prefer.
  
Bonus (Optional)
---
* Have more than one chatroom.
* Use .NET identity for users authentication
* Handle messages that are not understood or any exceptions raised within the bot.
* Build an installer.




## Tech Stack  

**Client:** React, Redux, TailwindCSS  

**Server:** Node, Express

## Features  

- Light/dark mode toggle  
- Live previews  
- Fullscreen mode  
- Cross platform 

## Lessons Learned  

What did you learn while building this project? What challenges did you face and how did you overcome t

## Run Locally  

Clone the project  

~~~bash  
  git clone https://link-to-project
~~~

Go to the project directory  

~~~bash  
  cd my-project
~~~

Install dependencies  

~~~bash  
npm install
~~~

Start the server  

~~~bash  
npm run start
~~~

## Environment Variables  

To run this project, you will need to add the following environment variables to your .env file  
`API_KEY`  

`ANOTHER_API_KEY` 

## Acknowledgements  

- [Awesome Readme Templates](https://awesomeopensource.com/project/elangosundar/awesome-README-templates)
- [Awesome README](https://github.com/matiassingers/awesome-readme)
- [How to write a Good readme](https://bulldogjob.com/news/449-how-to-write-a-good-readme-for-your-github-project)

## Feedback  

If you have any feedback, please reach out to us at fake@fake.com


[MIT](https://choosealicense.com/licenses/mit/)
