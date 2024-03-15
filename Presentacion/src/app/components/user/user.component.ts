import { Component } from '@angular/core';
import { UserFacade } from '../user.facade';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent {
  /**
   *Array que almacena los usuarios de la db
  */
  public users: User[] = [];

  public sortOrder: 'asc' | 'desc' = 'asc';

  /**
   *Constructor
  */
  constructor(private facade: UserFacade) { }

  /**
   *Método que trae los usuarios por medio de la fachada
  */
  getUsers(): void {
    this.facade.getUsers().subscribe(users => this.users = users);
  }

  toggleSort(key: string): void {
    this.sortOrder = this.sortOrder === 'asc' ? 'desc' : 'asc';
    this.sortUsers(key, this.sortOrder);
  }

  /**
   *Método que ordena los campos de la tabla según la key del objeto user
  */
  sortUsers(key: string, order: 'asc' | 'desc' = 'asc'): void {
    this.users.sort((a: any, b: any) => {
      if (order === 'asc') {
        return a[key] > b[key] ? 1 : -1;
      }

      return a[key] < b[key] ? 1 : -1;
    });
  }
}
