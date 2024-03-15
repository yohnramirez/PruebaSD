import { Injectable } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserFacade {

  /**
  *Constructor
 */
  constructor(private userService: UserService) { }

  /**
  *Obtiene usuarios de la capa de servicios
 */
  getUsers(): Observable<User[]> {
    return this.userService.getUsers();
  }

  /**
  *Guarda usuarios desde la capa de sercivios
 */
  saveUser(user : User): Observable<void> {
    return this.userService.saveUser(user);
  }

  /**
  *Actualiza usuarios desde la capa de servicios
 */
  updateUser(user: User): Observable<void> {
    return this.userService.saveUser(user);
  }

  /**
  *Elimina usuarios desde la capa de servicios
 */
  deleteUser(userId: number): Observable<void> {
    return this.userService.deleteUser(userId);
  }
}
