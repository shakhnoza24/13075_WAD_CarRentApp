import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

export const routes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "home",
        component: HomeComponent
    },
    {
        path: "create",
        component: HomeComponent
    },
    {
        path: "details/:id",
        component: HomeComponent
    },
    {
        path: "edit/:id",
        component: HomeComponent
    },
    {
        path: "delete/:id",
        component: HomeComponent
    }
];
