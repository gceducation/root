package com.gadreconsulting.BinaryTree;

public interface IBBTreeTraversalCallback<T> {
	boolean fHandle(Node<T> node);
}