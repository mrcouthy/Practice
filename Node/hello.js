var http=require('http');
http.createServer(function(request,response){
response.writeHead(200);
response.write("Hello Dj how are you?");
response.end();
}).listen(8081);
console.log('listening...');