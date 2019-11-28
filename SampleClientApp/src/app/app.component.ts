import { Component, OnInit } from '@angular/core';
import { UserService } from 'sample-webapi';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SampleClientApp';

  constructor(private userService: UserService) {
  }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(elem => {
      console.log(elem);
    });
  }
}
