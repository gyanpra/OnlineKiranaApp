import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  showPassword = true;
  showConfirmPassword = true;
  private unsubscribe$ = new Subject<void>();
  constructor() { }

  ngOnInit(): void {
  }

}
