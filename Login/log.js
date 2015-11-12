function clicked(){
	var user = document.getElementById('username');
	var pass = document.getElementById('password');
		
	var coruser ={
		username:"test",
		password:123,
	}; 
	
	if(user.value==coruser.username && pass.value==coruser.password){
		window.open("file:///C:/c34/Project/Home%20page/index.html");
	}else {
		document.write("incorrect user name or Password");
	}
		 }
function forgot(){
		var team = "<a href='https://myteamcare.org/reset_password.aspx'>myTeamCare</a>"
		document.write(team);
	}
	
	