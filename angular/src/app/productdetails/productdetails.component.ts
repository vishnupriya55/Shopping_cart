import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
  ProductListDto,
  ProductServiceProxy,
  UpdateProductInput,
  ProductListDtoListResultDto,
  ProductListDtoPagedResultDto,
  // ProductListDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import {CreateProductComponent } from './create-product/create-product.component';
import {EditProductComponent  } from './edit-product/edit-product.component';


class PagedProductsRequestDto extends PagedRequestDto {
  productName: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-productdetails',
  templateUrl: './productdetails.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./productdetails.component.css']
})
export class ProductdetailsComponent  extends PagedListingComponentBase<ProductListDto> {
  products: ProductListDto[] = [];
  productName = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _productService: ProductServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.getAllProducts("",0,10);
  }

  getAllProducts(productName: string,skipCount: number,maxResultCount: number){
    this._productService.getProductItems(productName,skipCount,maxResultCount)
    .pipe(
     finalize(() => {
       console.log("Error")
       // finishedCallback();
     })
    )
     .subscribe( data => { 
      console.log(data)
      this.products=data.items;
      this.totalItems=data.totalCount;
    });
   }

  createProduct(): void {
    this.showCreateOrEditProduct();
  }

  editProduct(product: UpdateProductInput): void {
    
    this.ShowEditProduct(product);
  }

  clearFilters(): void {
    this.productName = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedProductsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.productName = this.productName;
    request.isActive = this.isActive;

  
    

      this._productService
      .getProductItems(
        request.productName,
        //request.isActive,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: ProductListDtoPagedResultDto) => {
        this.products = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(product: ProductListDto): void {
    abp.message.confirm(
      this.l('ProductDeleteWarningMessage', product.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._productService.deleteProduct(product.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  

  private showCreateOrEditProduct(id?: number): void {
    let createOrEditProduct: BsModalRef;
    if (!id) {
      createOrEditProduct = this._modalService.show(
        CreateProductComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditProduct = this._modalService.show(
        EditProductComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditProduct.content.onSave.subscribe(() => {
      this.refresh();
    });
  }


  
  private ShowEditProduct(product: UpdateProductInput): void {
    let createOrEditProduct: BsModalRef;
    if (!product) {
      createOrEditProduct = this._modalService.show(
        CreateProductComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditProduct = this._modalService.show(
        EditProductComponent,
        {
          class: 'modal-lg',
          initialState: {
          productDetails : product
          },
        }
      );
    }

    createOrEditProduct.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}