import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserManagementService } from '../../services/user-management.service';
import { Subject, Subscription, catchError, defer, of, switchMap } from 'rxjs';
import { User, UserResult } from '../../models/user.model';
import { UserModalComponent } from '../../components/user-modal/user-modal.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-user-management-page',
  templateUrl: './user-management-page.component.html',
  styleUrl: './user-management-page.component.css',
})
export class UserManagementPageComponent implements OnInit, OnDestroy {
  userResult: UserResult;

  private _size: number;
  get size(): number {
    return this._size;
  }

  private _page: number;
  get page(): number {
    return this._page;
  }
  set page(value: number) {
    this._page = value;
    this._fetch$.next();
  }

  private _fetch$: Subject<void>;
  private _fetchSubscription!: Subscription;

  constructor(
    private _userManagementService: UserManagementService,
    private _ngbModalService: NgbModal
  ) {
    this.userResult = new UserResult({
      users: [],
      total: 0,
    });
    this._page = 1;
    this._size = 2;
    this._fetch$ = new Subject();
  }

  ngOnInit(): void {
    this.initialPaginationFetching();
    this._fetch$.next();
  }

  ngOnDestroy(): void {
    this._fetchSubscription.unsubscribe();
  }

  openAddModal(): void {
    const modalRef = this._ngbModalService.open(UserModalComponent, {
      size: 'lg',
    });

    const onClosedSubscription = modalRef.closed.subscribe({
      next: () => {
        this._fetch$.next();
        onClosedSubscription.unsubscribe();
      },
    });
  }

  openEditModal(user: User): void {
    const modalRef = this._ngbModalService.open(UserModalComponent, {
      size: 'lg',
    });

    modalRef.componentInstance.user = user;

    const onClosedSubscription = modalRef.closed.subscribe({
      next: () => {
        this._fetch$.next();
        onClosedSubscription.unsubscribe();
      },
    });
  }

  deleteUser(user: User): void {
    if (user.hn) {
      const onDeleteSubscription = this._userManagementService
        .deleteUser(user.hn)
        .subscribe({
          next: () => {
            this._fetch$.next();
            onDeleteSubscription.unsubscribe();
          },
        });
    }
  }

  private initialPaginationFetching() {
    this._fetchSubscription = this._fetch$
      .asObservable()
      .pipe(
        switchMap(() =>
          defer(() =>
            this._userManagementService.getUsers(this.page, this.size).pipe(
              catchError(() =>
                of<UserResult>(
                  new UserResult({
                    users: [],
                    total: this.userResult.total,
                  })
                )
              )
            )
          )
        )
      )
      .subscribe({
        next: (res) => {
          this.userResult = res;
        },
      });
  }
}
