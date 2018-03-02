import { Routes, RouterModule } from '@angular/router'
import { PedidoFormComponent } from './pedido/pages/pedido-form/pedido-form.component';
import { PedidoListComponent } from './pedido/pages/pedido-list/pedido-list.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
    //home
    {
        path: 'pedido/new',
        component: PedidoFormComponent
    },
    //Products
    {
        path: 'pedido/list',
        component: PedidoListComponent
    },
    { path: '',
    redirectTo: '/pedido/new',
    pathMatch: 'full'
    },
    { path: '**', component: PageNotFoundComponent }
     
];

export const RoutingModule = RouterModule.forRoot(routes);