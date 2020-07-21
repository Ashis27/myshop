import { Injectable } from '@angular/core';

@Injectable()
export class NotificationService {

    successMessage(message: string) {
        console.log(message);
    }

    errorMessage(message: string) {
        console.log(message);
    }
}
