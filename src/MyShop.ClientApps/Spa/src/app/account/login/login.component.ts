import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthService } from 'src/app/shared/authentication/auth.service';
import { ConfigService } from 'src/app/shared/services/config.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit { 

  constructor(private authService: AuthService, private spinner: NgxSpinnerService,
    private configService:ConfigService) { }    
  
    title = "Login";
    
    login() {     
      this.spinner.show();
      this.authService.login();
    }   

    ngOnInit() {
      this.configService.settingsLoaded$.subscribe((res)=>{
        console.log(res);
      })
    }
}


 