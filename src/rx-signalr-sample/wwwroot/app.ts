let source = Rx.Observable.create<number>((observer) => {

    setInterval(() => {

        observer.onNext(1);

    }, 1000);

});

source.bufferWithCount(3).subscribe(nexts => {
    for (let next of nexts) {
        console.warn(next);
    }
});

let hub = $.connection['sampleHub'];

hub.client.test = function () {

};

$.connection.hub.logging = true;

$.connection.hub.start();