import { Component, OnInit } from '@angular/core';
import { UserManagementService } from '../../services/user-management.service';
import { FormControl, FormsModule } from '@angular/forms';
import { AsyncPipe } from '@angular/common';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { User, UserResult } from '../../models/user.model';

@Component({
  selector: 'app-user-management-page',
  standalone: true,
  imports: [FormsModule, AsyncPipe, NgbPaginationModule],
  templateUrl: './user-management-page.component.html',
  styleUrl: './user-management-page.component.css',
})
export class UserManagementPageComponent implements OnInit {
  userResult!: UserResult;
  page: number;
  size: number;

  constructor(private _userManagementService: UserManagementService) {
    this.page = 1;
    this.size = 5;
  }

  ngOnInit(): void {
    this._userManagementService.getUsers().subscribe({
      next: (res) => {
        this.userResult = res;
      },
    });
  }
}
